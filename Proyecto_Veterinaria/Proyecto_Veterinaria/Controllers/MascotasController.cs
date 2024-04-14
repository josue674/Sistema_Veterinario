using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Veterinaria.DAL;

namespace Proyecto_Veterinaria.Controllers
{
    public class MascotasController : Controller
    {
        private readonly VeterinariaDbContext _context;
        private readonly UserManager<Usuario> _userManager;
        //Obtener el usuario loggeado
        private ClaimsIdentity identidad;
        private string idUsuarioLogeado;
        private string tipoUsuario;


        public MascotasController(VeterinariaDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            identidad = User.Identity as ClaimsIdentity;
            if (identidad != null)
            {
                idUsuarioLogeado = identidad.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                tipoUsuario = identidad.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            }
        }

        // GET: Mascotas
        public async Task<IActionResult> Index()
        {
            
            IQueryable<Mascota> query = _context.Mascotas
                .Include(m => m.Genr)
                .Include(m => m.Raza)
                .Include(m => m.TipoMascota)
                .Include(m => m.UsuarioCreacion)
                .Include(m => m.UsuarioModificacion)
                .Include(m => m.UsuarioDueno);

            if (tipoUsuario == "Cliente")
            {
                query = query.Where(m => m.UsuarioDuenoId == idUsuarioLogeado);
            }

            return View(await query.ToListAsync());
        }

        public async Task<JsonResult> GetRazasPorTipo(int tipoMascotaId)
        {
            // Suponiendo que tienes una relación definida para obtener las razas basadas en el tipo de mascota
            var razas = await _context.Razas
                                      .Where(r => r.TipoMascotaID == tipoMascotaId)
                                      .Select(r => new { value = r.RazaID, text = r.DescripcionRaza })
                                      .ToListAsync();

            return Json(new SelectList(razas, "value", "text"));
        }


        // GET: Mascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.Genr)
                .Include(m => m.Raza)
                .Include(m => m.TipoMascota)
                .Include(m => m.UsuarioCreacion)
                .Include(m => m.UsuarioModificacion)
                .Include(m => m.UsuarioDueno)
                .Include(m => m.Citas)
                .FirstOrDefaultAsync(m => m.MascotaID == id);

            // Filtrar las citas en históricas y próximas
            var citasHistoricas = mascota.Citas.Where(c => c.FechaHora < DateTime.Now).ToList();
            var citasProximas = mascota.Citas.Where(c => c.FechaHora >= DateTime.Now).ToList();

            // Asignar a ViewData
            ViewData["CitasHistoricas"] = citasHistoricas;
            ViewData["CitasProximas"] = citasProximas;
            ViewData["MascotaId"] = id;

            return View(mascota);
        }

        // GET: Mascotas/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["GeneroId"] = new SelectList(_context.Set<Genero>(), "GenroId", "TipoGenero");
            ViewData["RazaId"] = new SelectList(_context.Razas, "RazaID", "DescripcionRaza");
            ViewData["TipoMascotaId"] = new SelectList(_context.TiposMascota, "TipoMascotaID", "DescripcionTipo");
            ViewData["UsuarioCreacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre");
            ViewData["UsuarioModificacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre");
            var usersInRole = await _userManager.GetUsersInRoleAsync("Cliente");
            ViewData["UsuarioDuenoId"] = new SelectList(usersInRole, "Id", "Nombre");
            return View();
        }

        // POST: Mascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Mascota mascota, IFormFile ImagenMascota)
        {
            if (ModelState.IsValid)
            {

                // Transformación
                Mascota nuevaMascota = new()
                {
                    NombreMascota = mascota.NombreMascota,
                    TipoMascotaId = mascota.TipoMascotaId,
                    RazaId = mascota.RazaId,
                    GeneroId = mascota.GeneroId,
                    Edad = mascota.Edad,
                    Peso = mascota.Peso,
                    ImagenMascota = mascota.ImagenMascota,
                    FechaCreacion = DateTime.Now,
                    UsuarioCreacionId = idUsuarioLogeado,
                    FechaModificacion = DateTime.Now,
                    UsuarioModificacionId = idUsuarioLogeado,
                    Estado = true
                };

                if (ImagenMascota != null && ImagenMascota.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await ImagenMascota.CopyToAsync(stream);
                        nuevaMascota.ImagenMascota = stream.ToArray();
                    }
                }

                if (tipoUsuario == "Cliente")
                {
                    nuevaMascota.UsuarioDuenoId = idUsuarioLogeado;
                }
                else
                {
                    nuevaMascota.UsuarioDuenoId = mascota.UsuarioDuenoId;
                }
                _context.Add(nuevaMascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMacota"] = mascota.MascotaID;
            ViewData["GeneroId"] = new SelectList(_context.Set<Genero>(), "GenroId", "TipoGenero", mascota.GeneroId);
            ViewData["RazaId"] = new SelectList(_context.Razas, "RazaID", "DescripcionRaza", mascota.RazaId);
            ViewData["TipoMascotaId"] = new SelectList(_context.TiposMascota, "TipoMascotaID", "DescripcionTipo", mascota.TipoMascotaId);
            ViewData["UsuarioCreacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", mascota.UsuarioCreacionId);
            ViewData["UsuarioModificacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", mascota.UsuarioModificacionId);
            ViewData["UsuarioDuenoId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", mascota.UsuarioDuenoId);
            return View(mascota);
        }

        public async Task<IActionResult> GetImagenMascota(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);

            if (mascota == null || mascota.ImagenMascota == null)
            {
                return NotFound();
            }

            return File(mascota.ImagenMascota, "image/jpeg"); // Ajusta el tipo MIME según sea necesario.
        }

        // GET: Mascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            ViewData["GeneroId"] = new SelectList(_context.Set<Genero>(), "GenroId", "TipoGenero", mascota.GeneroId);
            ViewData["RazaId"] = new SelectList(_context.Razas, "RazaID", "DescripcionRaza", mascota.RazaId);
            ViewData["TipoMascotaId"] = new SelectList(_context.TiposMascota, "TipoMascotaID", "DescripcionTipo", mascota.TipoMascotaId);
            ViewData["UsuarioCreacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", mascota.UsuarioCreacionId);
            ViewData["UsuarioModificacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", mascota.UsuarioModificacionId);
            ViewData["UsuarioDuenoId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", mascota.UsuarioDuenoId);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Mascota mascota)
        {
            if (id != mascota.MascotaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var mascotaParaActualizar = await _context.Mascotas.FindAsync(id);
                if (mascotaParaActualizar == null)
                {
                    return NotFound();
                }

                try
                {
                    // Actualizar las propiedades de la mascota existente con los nuevos valores
                    mascotaParaActualizar.Edad = mascota.Edad;
                    mascotaParaActualizar.Peso = mascota.Peso;
                    mascotaParaActualizar.FechaModificacion = DateTime.Now;
                    mascotaParaActualizar.UsuarioModificacionId = idUsuarioLogeado;
                    mascotaParaActualizar.Estado = mascota.Estado;

                    // _context.Update(editMascota); // No es necesario si usas rastreo automático de entidades
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotaExists(mascota.MascotaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroId"] = new SelectList(_context.Set<Genero>(), "GenroId", "TipoGenero", mascota.GeneroId);
            ViewData["RazaId"] = new SelectList(_context.Razas, "RazaID", "DescripcionRaza", mascota.RazaId);
            ViewData["TipoMascotaId"] = new SelectList(_context.TiposMascota, "TipoMascotaID", "DescripcionTipo", mascota.TipoMascotaId);
            ViewData["UsuarioCreacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Id", mascota.UsuarioCreacionId);
            ViewData["UsuarioModificacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Id", mascota.UsuarioModificacionId);
            ViewData["UsuarioDuenoId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", mascota.UsuarioDuenoId);
            return View(mascota);
        }

        // GET: Mascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.Genr)
                .Include(m => m.Raza)
                .Include(m => m.TipoMascota)
                .Include(m => m.UsuarioCreacion)
                .Include(m => m.UsuarioModificacion)
                .FirstOrDefaultAsync(m => m.MascotaID == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota != null)
            {
                // Cambiar el estado a 'borrado' en lugar de eliminarlo físicamente
                mascota.Estado = false; // Asumiendo que 'false' representa borrado
                _context.Update(mascota);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MascotaExists(int id)
        {
            return _context.Mascotas.Any(e => e.MascotaID == id);
        }
    }
}
