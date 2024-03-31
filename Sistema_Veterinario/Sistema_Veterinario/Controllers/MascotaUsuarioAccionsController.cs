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
    public class MascotaUsuarioAccionsController : Controller
    {
        private readonly Sistema_VeterinarioDbContext _context;

        public MascotaUsuarioAccionsController(Sistema_VeterinarioDbContext context)
        {
            _context = context;
        }

        // GET: MascotaUsuarioAccions
        public async Task<IActionResult> Index()
        {
            var sistema_VeterinarioDbContext = _context.MascotaUsuarioAcciones.Include(m => m.Mascota).Include(m => m.UsuarioCreacion).Include(m => m.UsuarioModificacion);
            return View(await sistema_VeterinarioDbContext.ToListAsync());
        }

        // GET: MascotaUsuarioAccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotaUsuarioAccion = await _context.MascotaUsuarioAcciones
                .Include(m => m.Mascota)
                .Include(m => m.UsuarioCreacion)
                .Include(m => m.UsuarioModificacion)
                .FirstOrDefaultAsync(m => m.MascotaID == id);
            if (mascotaUsuarioAccion == null)
            {
                return NotFound();
            }

            return View(mascotaUsuarioAccion);
        }

        // GET: MascotaUsuarioAccions/Create
        public IActionResult Create()
        {
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "Genero");
            ViewData["UsuarioCreacionID"] = new SelectList(_context.Usuarios, "UsuarioID", "Contraseña");
            ViewData["UsuarioModificacionID"] = new SelectList(_context.Usuarios, "UsuarioID", "Contraseña");
            return View();
        }

        // POST: MascotaUsuarioAccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MascotaID,UsuarioModificacionID,UsuarioCreacionID")] MascotaUsuarioAccion mascotaUsuarioAccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascotaUsuarioAccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "Genero", mascotaUsuarioAccion.MascotaID);
            ViewData["UsuarioCreacionID"] = new SelectList(_context.Usuarios, "UsuarioID", "Contraseña", mascotaUsuarioAccion.UsuarioCreacionID);
            ViewData["UsuarioModificacionID"] = new SelectList(_context.Usuarios, "UsuarioID", "Contraseña", mascotaUsuarioAccion.UsuarioModificacionID);
            return View(mascotaUsuarioAccion);
        }

        // GET: MascotaUsuarioAccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotaUsuarioAccion = await _context.MascotaUsuarioAcciones.FindAsync(id);
            if (mascotaUsuarioAccion == null)
            {
                return NotFound();
            }
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "Genero", mascotaUsuarioAccion.MascotaID);
            ViewData["UsuarioCreacionID"] = new SelectList(_context.Usuarios, "UsuarioID", "Contraseña", mascotaUsuarioAccion.UsuarioCreacionID);
            ViewData["UsuarioModificacionID"] = new SelectList(_context.Usuarios, "UsuarioID", "Contraseña", mascotaUsuarioAccion.UsuarioModificacionID);
            return View(mascotaUsuarioAccion);
        }

        // POST: MascotaUsuarioAccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MascotaID,UsuarioModificacionID,UsuarioCreacionID")] MascotaUsuarioAccion mascotaUsuarioAccion)
        {
            if (id != mascotaUsuarioAccion.MascotaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascotaUsuarioAccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotaUsuarioAccionExists(mascotaUsuarioAccion.MascotaID))
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
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "Genero", mascotaUsuarioAccion.MascotaID);
            ViewData["UsuarioCreacionID"] = new SelectList(_context.Usuarios, "UsuarioID", "Contraseña", mascotaUsuarioAccion.UsuarioCreacionID);
            ViewData["UsuarioModificacionID"] = new SelectList(_context.Usuarios, "UsuarioID", "Contraseña", mascotaUsuarioAccion.UsuarioModificacionID);
            return View(mascotaUsuarioAccion);
        }

        // GET: MascotaUsuarioAccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotaUsuarioAccion = await _context.MascotaUsuarioAcciones
                .Include(m => m.Mascota)
                .Include(m => m.UsuarioCreacion)
                .Include(m => m.UsuarioModificacion)
                .FirstOrDefaultAsync(m => m.MascotaID == id);
            if (mascotaUsuarioAccion == null)
            {
                return NotFound();
            }

            return View(mascotaUsuarioAccion);
        }

        // POST: MascotaUsuarioAccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascotaUsuarioAccion = await _context.MascotaUsuarioAcciones.FindAsync(id);
            if (mascotaUsuarioAccion != null)
            {
                _context.MascotaUsuarioAcciones.Remove(mascotaUsuarioAccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotaUsuarioAccionExists(int id)
        {
            return _context.MascotaUsuarioAcciones.Any(e => e.MascotaID == id);
        }
    }
}
