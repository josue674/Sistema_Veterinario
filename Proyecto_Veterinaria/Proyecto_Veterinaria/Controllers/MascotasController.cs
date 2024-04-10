using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
        //Obtener el usuario loggeado
        private ClaimsIdentity identidad;
        private string idUsuarioLogeado;
        private string tipoUsuario;

        //private var identidad = User.Identity as ClaimsIdentity;
        // privatestring idUsuarioLogeado = identidad.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        //string tipoUsuario = identidad.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

        public MascotasController(VeterinariaDbContext context)
        {
            _context = context;
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
            var identidad = User.Identity as ClaimsIdentity;
            string userId = identidad.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            string userType = identidad.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            IQueryable<Mascota> query = _context.Mascotas
                .Include(m => m.Genr)
                .Include(m => m.Raza)
                .Include(m => m.TipoMascota)
                .Include(m => m.UsuarioCreacion)
                .Include(m => m.UsuarioModificacion);

            if (userType == "Cliente")
            {
                query = query.Where(m => m.UsuarioDuenoId == userId);
            }

            return View(await query.ToListAsync());
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
        public IActionResult Create()
        {
            ViewData["GeneroId"] = new SelectList(_context.Set<Genero>(), "GenroId", "TipoGenero");
            ViewData["RazaId"] = new SelectList(_context.Razas, "RazaID", "DescripcionRaza");
            ViewData["TipoMascotaId"] = new SelectList(_context.TiposMascota, "TipoMascotaID", "DescripcionTipo");
            ViewData["UsuarioCreacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre");
            ViewData["UsuarioModificacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre");
            ViewData["UsuarioDuenoId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre");
            return View();
        }

        // POST: Mascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Mascota mascota)
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

                if(tipoUsuario == "Cliente")
                {
                    nuevaMascota.UsuarioDuenoId = idUsuarioLogeado;
                }
                else
                {
                    nuevaMascota.UsuarioDueno = mascota.UsuarioDueno;
                }
                _context.Add(nuevaMascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroId"] = new SelectList(_context.Set<Genero>(), "GenroId", "TipoGenero", mascota.GeneroId);
            ViewData["RazaId"] = new SelectList(_context.Razas, "RazaID", "DescripcionRaza", mascota.RazaId);
            ViewData["TipoMascotaId"] = new SelectList(_context.TiposMascota, "TipoMascotaID", "DescripcionTipo", mascota.TipoMascotaId);
            ViewData["UsuarioCreacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", mascota.UsuarioCreacionId);
            ViewData["UsuarioModificacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", mascota.UsuarioModificacionId);
            ViewData["UsuarioDuenoId"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", mascota.UsuarioDuenoId);
            return View(mascota);
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
                try
                {
                    // Transformación
                    Mascota editMascota = new()
                    {
                        NombreMascota = mascota.NombreMascota,
                        TipoMascotaId = mascota.TipoMascotaId,
                        RazaId = mascota.RazaId,
                        GeneroId = mascota.GeneroId,
                        Edad = mascota.Edad,
                        Peso = mascota.Peso,
                        ImagenMascota = mascota.ImagenMascota,
                        FechaCreacion = mascota.FechaCreacion,
                        UsuarioCreacionId = mascota.UsuarioCreacionId,
                        UsuarioDuenoId = mascota.UsuarioDuenoId,
                        FechaModificacion = DateTime.Now,
                        UsuarioModificacionId = idUsuarioLogeado,
                        Estado = mascota.Estado
                    };

                    _context.Update(editMascota);
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
