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
    public class CitasController : Controller
    {
        private readonly Sistema_VeterinarioDbContext _context;

        public CitasController(Sistema_VeterinarioDbContext context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var sistema_VeterinarioDbContext = _context.Citas.Include(c => c.EstadoCita).Include(c => c.Mascota).Include(c => c.VeterinarioPrincipal).Include(c => c.VeterinarioSecundario);
            return View(await sistema_VeterinarioDbContext.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .Include(c => c.EstadoCita)
                .Include(c => c.Mascota)
                .Include(c => c.VeterinarioPrincipal)
                .Include(c => c.VeterinarioSecundario)
                .FirstOrDefaultAsync(m => m.CitaID == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            ViewData["EstadoCitaID"] = new SelectList(_context.EstadoCitas, "EstadoCitaID", "EstadoCitaNombre");
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "Genero");
            ViewData["VeterinarioPrincipalID"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Id");
            ViewData["VeterinarioSecundarioID"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Id");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitaID,MascotaID,FechaHora,VeterinarioPrincipalID,VeterinarioSecundarioID,Descripcion,Diagnostico,EstadoCitaID")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoCitaID"] = new SelectList(_context.EstadoCitas, "EstadoCitaID", "EstadoCitaNombre", cita.EstadoCitaID);
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "Genero", cita.MascotaID);
            ViewData["VeterinarioPrincipalID"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Id", cita.VeterinarioPrincipalID);
            ViewData["VeterinarioSecundarioID"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Id", cita.VeterinarioSecundarioID);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["EstadoCitaID"] = new SelectList(_context.EstadoCitas, "EstadoCitaID", "EstadoCitaNombre", cita.EstadoCitaID);
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "Genero", cita.MascotaID);
            ViewData["VeterinarioPrincipalID"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Id", cita.VeterinarioPrincipalID);
            ViewData["VeterinarioSecundarioID"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Id", cita.VeterinarioSecundarioID);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitaID,MascotaID,FechaHora,VeterinarioPrincipalID,VeterinarioSecundarioID,Descripcion,Diagnostico,EstadoCitaID")] Cita cita)
        {
            if (id != cita.CitaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.CitaID))
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
            ViewData["EstadoCitaID"] = new SelectList(_context.EstadoCitas, "EstadoCitaID", "EstadoCitaNombre", cita.EstadoCitaID);
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "Genero", cita.MascotaID);
            ViewData["VeterinarioPrincipalID"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Id", cita.VeterinarioPrincipalID);
            ViewData["VeterinarioSecundarioID"] = new SelectList(_context.Set<UsuarioApplication>(), "Id", "Id", cita.VeterinarioSecundarioID);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .Include(c => c.EstadoCita)
                .Include(c => c.Mascota)
                .Include(c => c.VeterinarioPrincipal)
                .Include(c => c.VeterinarioSecundario)
                .FirstOrDefaultAsync(m => m.CitaID == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Citas.Any(e => e.CitaID == id);
        }
    }
}
