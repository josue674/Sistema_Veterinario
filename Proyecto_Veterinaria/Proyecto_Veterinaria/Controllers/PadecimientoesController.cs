using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Veterinaria.DAL;

namespace Proyecto_Veterinaria.Controllers
{
    public class PadecimientoesController : Controller
    {
        private readonly VeterinariaDbContext _context;

        public PadecimientoesController(VeterinariaDbContext context)
        {
            _context = context;
        }

        // GET: Padecimientoes
        public async Task<IActionResult> Index()
        {
            var veterinariaDbContext = _context.Padecimientos.Include(p => p.Mascota);
            return View(await veterinariaDbContext.ToListAsync());
        }

        // GET: Padecimientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padecimiento = await _context.Padecimientos
                .Include(p => p.Mascota)
                .FirstOrDefaultAsync(m => m.PadecimientoID == id);
            if (padecimiento == null)
            {
                return NotFound();
            }

            return View(padecimiento);
        }

        // GET: Padecimientoes/Create
        public IActionResult Create()
        {
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota");
            return View();
        }

        // POST: Padecimientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PadecimientoID,MascotaID,Descripcion")] Padecimiento padecimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(padecimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota", padecimiento.MascotaID);
            return View(padecimiento);
        }

        // GET: Padecimientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padecimiento = await _context.Padecimientos.FindAsync(id);
            if (padecimiento == null)
            {
                return NotFound();
            }
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota", padecimiento.MascotaID);
            return View(padecimiento);
        }

        // POST: Padecimientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PadecimientoID,MascotaID,Descripcion")] Padecimiento padecimiento)
        {
            if (id != padecimiento.PadecimientoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padecimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadecimientoExists(padecimiento.PadecimientoID))
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
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota", padecimiento.MascotaID);
            return View(padecimiento);
        }

        // GET: Padecimientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padecimiento = await _context.Padecimientos
                .Include(p => p.Mascota)
                .FirstOrDefaultAsync(m => m.PadecimientoID == id);
            if (padecimiento == null)
            {
                return NotFound();
            }

            return View(padecimiento);
        }

        // POST: Padecimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var padecimiento = await _context.Padecimientos.FindAsync(id);
            if (padecimiento != null)
            {
                _context.Padecimientos.Remove(padecimiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadecimientoExists(int id)
        {
            return _context.Padecimientos.Any(e => e.PadecimientoID == id);
        }
    }
}
