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
    public class MedicamentoCitasController : Controller
    {
        private readonly VeterinariaDbContext _context;

        public MedicamentoCitasController(VeterinariaDbContext context)
        {
            _context = context;
        }

        // GET: MedicamentoCitas
        public async Task<IActionResult> Index()
        {
            var veterinariaDbContext = _context.MedicamentoCitas.Include(m => m.Cita).Include(m => m.Medicamento);
            return View(await veterinariaDbContext.ToListAsync());
        }

        // GET: MedicamentoCitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentoCita = await _context.MedicamentoCitas
                .Include(m => m.Cita)
                .Include(m => m.Medicamento)
                .FirstOrDefaultAsync(m => m.MedicamentoCitaID == id);
            if (medicamentoCita == null)
            {
                return NotFound();
            }

            return View(medicamentoCita);
        }

        // GET: MedicamentoCitas/Create
        public IActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewData["CitaID"] = id.Value;
            }
            ViewData["MedicamentoID"] = new SelectList(_context.Medicamentos, "MedicamentoID", "NombreMedicamento");
            return View();
        }

        // POST: MedicamentoCitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicamentoCitaID,CitaID,MedicamentoID,Dosis")] MedicamentoCita medicamentoCita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamentoCita);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", "Citas", new { id = medicamentoCita.CitaID });
            }
            ViewData["CitaID"] = new SelectList(_context.Citas, "CitaID", "Descripcion", medicamentoCita.CitaID);
            ViewData["MedicamentoID"] = new SelectList(_context.Medicamentos, "MedicamentoID", "NombreMedicamento", medicamentoCita.MedicamentoID);
            return View(medicamentoCita);
        }

        // GET: MedicamentoCitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentoCita = await _context.MedicamentoCitas.FindAsync(id);
            if (medicamentoCita == null)
            {
                return NotFound();
            }
            ViewData["CitaID"] = new SelectList(_context.Citas, "CitaID", "Descripcion", medicamentoCita.CitaID);
            ViewData["MedicamentoID"] = new SelectList(_context.Medicamentos, "MedicamentoID", "NombreMedicamento", medicamentoCita.MedicamentoID);
            return View(medicamentoCita);
        }

        // POST: MedicamentoCitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicamentoCitaID,CitaID,MedicamentoID,Dosis")] MedicamentoCita medicamentoCita)
        {
            if (id != medicamentoCita.MedicamentoCitaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamentoCita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentoCitaExists(medicamentoCita.MedicamentoCitaID))
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
            ViewData["CitaID"] = new SelectList(_context.Citas, "CitaID", "Descripcion", medicamentoCita.CitaID);
            ViewData["MedicamentoID"] = new SelectList(_context.Medicamentos, "MedicamentoID", "NombreMedicamento", medicamentoCita.MedicamentoID);
            return View(medicamentoCita);
        }

        // GET: MedicamentoCitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentoCita = await _context.MedicamentoCitas
                .Include(m => m.Cita)
                .Include(m => m.Medicamento)
                .FirstOrDefaultAsync(m => m.MedicamentoCitaID == id);
            if (medicamentoCita == null)
            {
                return NotFound();
            }

            return View(medicamentoCita);
        }

        // POST: MedicamentoCitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicamentoCita = await _context.MedicamentoCitas.FindAsync(id);
            if (medicamentoCita != null)
            {
                _context.MedicamentoCitas.Remove(medicamentoCita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentoCitaExists(int id)
        {
            return _context.MedicamentoCitas.Any(e => e.MedicamentoCitaID == id);
        }
    }
}
