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
    public class TipoMascotasController : Controller
    {
        private readonly Sistema_VeterinarioDbContext _context;

        public TipoMascotasController(Sistema_VeterinarioDbContext context)
        {
            _context = context;
        }

        // GET: TipoMascotas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposMascota.ToListAsync());
        }

        // GET: TipoMascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMascota = await _context.TiposMascota
                .FirstOrDefaultAsync(m => m.TipoMascotaID == id);
            if (tipoMascota == null)
            {
                return NotFound();
            }

            return View(tipoMascota);
        }

        // GET: TipoMascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoMascotaID,DescripcionTipo")] TipoMascota tipoMascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMascota);
        }

        // GET: TipoMascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMascota = await _context.TiposMascota.FindAsync(id);
            if (tipoMascota == null)
            {
                return NotFound();
            }
            return View(tipoMascota);
        }

        // POST: TipoMascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoMascotaID,DescripcionTipo")] TipoMascota tipoMascota)
        {
            if (id != tipoMascota.TipoMascotaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMascotaExists(tipoMascota.TipoMascotaID))
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
            return View(tipoMascota);
        }

        // GET: TipoMascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMascota = await _context.TiposMascota
                .FirstOrDefaultAsync(m => m.TipoMascotaID == id);
            if (tipoMascota == null)
            {
                return NotFound();
            }

            return View(tipoMascota);
        }

        // POST: TipoMascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMascota = await _context.TiposMascota.FindAsync(id);
            if (tipoMascota != null)
            {
                _context.TiposMascota.Remove(tipoMascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMascotaExists(int id)
        {
            return _context.TiposMascota.Any(e => e.TipoMascotaID == id);
        }
    }
}
