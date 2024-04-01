using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Veterinario.DAL;

namespace Sistema_Veterinario.Controllers
{
    public class MascotasController : Controller
    {
        private readonly Sistema_VeterinarioDbContext _context;

        public MascotasController(Sistema_VeterinarioDbContext context)
        {
            _context = context;
        }

        // GET: Mascotas
        public async Task<IActionResult> Index()
        {
            var sistema_VeterinarioDbContext = _context.Mascotas.Include(m => m.Raza).Include(m => m.TipoMascota).Include(m => m.UsuarioCreacion).Include(m => m.UsuarioModificacion);
            return View(await sistema_VeterinarioDbContext.ToListAsync());
        }

        // GET: Mascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
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
            ViewData["RazaID"] = new SelectList(_context.Razas, "RazaID", "DescripcionRaza");
            ViewData["TipoMascotaID"] = new SelectList(_context.TiposMascota, "TipoMascotaID", "DescripcionTipo");
            ViewData["UsuarioCreacionId"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Nombre");
            ViewData["UsuarioModificacionId"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Nombre");
            return View();
        }

        // POST: Mascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MascotaID,NombreMascota,TipoMascotaID,RazaID,Genero,Edad,Peso,UsuarioCreacionId,UsuarioModificacionId,ImagenMascota,FechaCreacion,FechaModificacion,Estado")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RazaID"] = new SelectList(_context.Razas, "RazaID", "DescripcionRaza", mascota.RazaID);
            ViewData["TipoMascotaID"] = new SelectList(_context.TiposMascota, "TipoMascotaID", "DescripcionTipo", mascota.TipoMascotaID);
            ViewData["UsuarioCreacionId"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Nombre", mascota.UsuarioCreacionId);
            ViewData["UsuarioModificacionId"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Nombre", mascota.UsuarioModificacionId);
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
            ViewData["RazaID"] = new SelectList(_context.Razas, "RazaID", "DescripcionRaza", mascota.RazaID);
            ViewData["TipoMascotaID"] = new SelectList(_context.TiposMascota, "TipoMascotaID", "DescripcionTipo", mascota.TipoMascotaID);
            ViewData["UsuarioCreacionId"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Nombre", mascota.UsuarioCreacionId);
            ViewData["UsuarioModificacionId"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Nombre", mascota.UsuarioModificacionId);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MascotaID,NombreMascota,TipoMascotaID,RazaID,Genero,Edad,Peso,UsuarioCreacionId,UsuarioModificacionId,ImagenMascota,FechaCreacion,FechaModificacion,Estado")] Mascota mascota)
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
            ViewData["RazaID"] = new SelectList(_context.Razas, "RazaID", "DescripcionRaza", mascota.RazaID);
            ViewData["TipoMascotaID"] = new SelectList(_context.TiposMascota, "TipoMascotaID", "DescripcionTipo", mascota.TipoMascotaID);
            ViewData["UsuarioCreacionId"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Nombre", mascota.UsuarioCreacionId);
            ViewData["UsuarioModificacionId"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Nombre", mascota.UsuarioModificacionId);
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
