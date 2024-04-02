using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Veterinario.DAL;
using Sistema_Veterinario.Models;

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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var sistema_VeterinarioDbContext = _context.Mascotas.Include(m => m.Raza).Include(m => m.TipoMascota).Include(m => m.UsuarioCreacion).Include(m => m.UsuarioModificacion);
            return View(await sistema_VeterinarioDbContext.ToListAsync());

            /*if (User.IsInRole("Cliente"))
            {
                // Obtener el ID del cliente actual
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                // Filtrar las mascotas del cliente actual
                var mascotas = await _context.Mascotas
                    .Where(m => m.UsuarioCreacionId == userId)
                    .ToListAsync();
                return View(mascotas);
            }
            else // Si es un veterinario, mostrar todas las mascotas
            {
                var mascotas = await _context.Mascotas.ToListAsync();
                return View(mascotas);
            }*/
        }

        // GET: Mascotas/Details/5
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Create(MascotaCreateViewModel mascota)
        {
            if (ModelState.IsValid)
            {
                //Obtener el usuario loggeado
                var identidad = User.Identity as ClaimsIdentity;
                string idUsuarioLogeado = identidad.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

                // Transformación
                Mascota masco = new Mascota
                {
                    NombreMascota = mascota.NombreMascota,
                    TipoMascotaID = mascota.TipoMascotaID,
                    RazaID = mascota.RazaID,
                    Genero = mascota.Genero,
                    Edad = mascota.Edad,
                    Peso = mascota.Peso,
                    ImagenMascota = mascota.ImagenMascota,
                    FechaCreacion = DateTime.Now,
                    UsuarioCreacionId = idUsuarioLogeado,
                    FechaModificacion = DateTime.Now,
                    UsuarioModificacionId = idUsuarioLogeado,
                    Estado = mascota.Estado

                };

                _context.Add(masco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RazaID"] = new SelectList(_context.Razas, "RazaID", "DescripcionRaza", mascota.RazaID);
            ViewData["TipoMascotaID"] = new SelectList(_context.TiposMascota, "TipoMascotaID", "DescripcionTipo", mascota.TipoMascotaID);
            return View(mascota);
        }

        // GET: Mascotas/Edit/5
        [Authorize(Roles = "Cliente, Veterinario")]
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
        [Authorize(Roles = "Cliente, Veterinario")]
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