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
    public class DesparasitacionVacunasController : Controller
    {
        private readonly VeterinariaDbContext _context;

        private ClaimsIdentity identidad;
        private string tipoUsuario;


        public DesparasitacionVacunasController(VeterinariaDbContext context)
        {
            _context = context;

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            identidad = User.Identity as ClaimsIdentity;
            if (identidad != null)
            {
                tipoUsuario = identidad.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            }
        }

        // GET: DesparasitacionVacunas
        public async Task<IActionResult> Index(int? IdMascota)
        {
            if (tipoUsuario == "Veterinario")
            {
                var veterinariaDbContext = _context.DesparasitacionVacunas.Include(d => d.Mascota);
                return View(await veterinariaDbContext.ToListAsync());
            }
            else if (tipoUsuario == "Cliente")
            {
                // El cliente solo puede ver los registros de una mascota específica
                if (IdMascota == null)
                {
                    // Si no se proporciona un ID de mascota, se muestra un error o una página vacía
                    // Aquí podrías redirigir a una página de error o simplemente no mostrar registros
                    return View(new List<DesparasitacionVacuna>());  // Devuelve una lista vacía
                }
                else
                {
                    // Filtra los registros por el ID de la mascota
                    var veterinariaDbContextClient = _context.DesparasitacionVacunas
                                                             .Include(d => d.Mascota)
                                                             .Where(d => d.MascotaID == IdMascota);
                    return View(await veterinariaDbContextClient.ToListAsync());
                }
            }
            else
            {
                // Si el usuario no es ni veterinario ni cliente, o para cualquier otro caso no contemplado
                // Similar a los clientes, puedes decidir no mostrar registros o manejar de otra manera
                return View(new List<DesparasitacionVacuna>());  // Devuelve una lista vacía
            }
        }

        // GET: DesparasitacionVacunas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desparasitacionVacuna = await _context.DesparasitacionVacunas
                .Include(d => d.Mascota)
                .FirstOrDefaultAsync(m => m.DesparasitacionVacunaID == id);
            if (desparasitacionVacuna == null)
            {
                return NotFound();
            }

            return View(desparasitacionVacuna);
        }

        // GET: DesparasitacionVacunas/Create
        public IActionResult Create()
        {
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota");
            return View();
        }

        // POST: DesparasitacionVacunas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesparasitacionVacunaID,MascotaID,Tipo,Fecha,Producto")] DesparasitacionVacuna desparasitacionVacuna)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desparasitacionVacuna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota", desparasitacionVacuna.MascotaID);
            return View(desparasitacionVacuna);
        }

        // GET: DesparasitacionVacunas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desparasitacionVacuna = await _context.DesparasitacionVacunas.FindAsync(id);
            if (desparasitacionVacuna == null)
            {
                return NotFound();
            }
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota", desparasitacionVacuna.MascotaID);
            return View(desparasitacionVacuna);
        }

        // POST: DesparasitacionVacunas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DesparasitacionVacunaID,MascotaID,Tipo,Fecha,Producto")] DesparasitacionVacuna desparasitacionVacuna)
        {
            if (id != desparasitacionVacuna.DesparasitacionVacunaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desparasitacionVacuna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesparasitacionVacunaExists(desparasitacionVacuna.DesparasitacionVacunaID))
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
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota", desparasitacionVacuna.MascotaID);
            return View(desparasitacionVacuna);
        }

        // GET: DesparasitacionVacunas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desparasitacionVacuna = await _context.DesparasitacionVacunas
                .Include(d => d.Mascota)
                .FirstOrDefaultAsync(m => m.DesparasitacionVacunaID == id);
            if (desparasitacionVacuna == null)
            {
                return NotFound();
            }

            return View(desparasitacionVacuna);
        }

        // POST: DesparasitacionVacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var desparasitacionVacuna = await _context.DesparasitacionVacunas.FindAsync(id);
            if (desparasitacionVacuna != null)
            {
                _context.DesparasitacionVacunas.Remove(desparasitacionVacuna);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesparasitacionVacunaExists(int id)
        {
            return _context.DesparasitacionVacunas.Any(e => e.DesparasitacionVacunaID == id);
        }
    }
}
