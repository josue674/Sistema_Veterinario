using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Veterinaria.DAL;

namespace Proyecto_Veterinaria.Controllers
{
    public class MascotasController : Controller
    {
        private readonly VeterinariaDbContext _context;

        public MascotasController(VeterinariaDbContext context)
        {
            _context = context;
        }

        // GET: Mascotas
        public async Task<IActionResult> Index()
        {
            var veterinariaDbContext = _context.Mascotas.Include(m => m.Genr).Include(m => m.Raza).Include(m => m.TipoMascota).Include(m => m.UsuarioCreacion).Include(m => m.UsuarioModificacion);
            return View(await veterinariaDbContext.ToListAsync());
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
                .FirstOrDefaultAsync(m => m.MascotaID == id);
            if (mascota == null)
            {
                return NotFound();
            }

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
                //Obtener el usuario loggeado
                var identidad = User.Identity as ClaimsIdentity;
                string idUsuarioLogeado = identidad.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                string tipoUsuario = identidad.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value; 


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
            ViewData["UsuarioCreacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Id", mascota.UsuarioCreacionId);
            ViewData["UsuarioModificacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Id", mascota.UsuarioModificacionId);
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
            ViewData["UsuarioCreacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Id", mascota.UsuarioCreacionId);
            ViewData["UsuarioModificacionId"] = new SelectList(_context.Set<Usuario>(), "Id", "Id", mascota.UsuarioModificacionId);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MascotaID,NombreMascota,TipoMascotaId,RazaId,GeneroId,Edad,Peso,UsuarioCreacionId,UsuarioModificacionId,ImagenMascota,FechaCreacion,FechaModificacion,Estado")] Mascota mascota)
        {
            if (id != mascota.MascotaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascota);
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
                _context.Mascotas.Remove(mascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotaExists(int id)
        {
            return _context.Mascotas.Any(e => e.MascotaID == id);
        }
    }
}
