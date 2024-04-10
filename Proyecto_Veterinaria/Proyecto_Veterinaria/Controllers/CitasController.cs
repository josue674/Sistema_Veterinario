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
    public class CitasController : Controller
    {
        private readonly VeterinariaDbContext _context;

        public CitasController(VeterinariaDbContext context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var veterinariaDbContext = _context.Citas.Include(c => c.EstadoCita).Include(c => c.Mascota).Include(c => c.VeterinarioPrincipal).Include(c => c.VeterinarioSecundario);
            return View(await veterinariaDbContext.ToListAsync());
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
                .Include(c => c.MedicamentosCita).ThenInclude(mc => mc.Medicamento)
                .Include(c => c.VeterinarioPrincipal)
                .Include(c => c.VeterinarioSecundario)
                .FirstOrDefaultAsync(m => m.CitaID == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        public async Task<IActionResult> DetailsMascota(int? id, int? ownerId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .Include(c => c.EstadoCita)
                .Include(c => c.Mascota)
                .Include(c => c.MedicamentosCita).ThenInclude(mc => mc.Medicamento)
                .Include(c => c.VeterinarioPrincipal)
                .Include(c => c.VeterinarioSecundario)
                .FirstOrDefaultAsync(m => m.CitaID == id);
            if (cita == null)
            {
                return NotFound();
            }

            ViewData["MascotaId"] = ownerId;

            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            ViewData["EstadoCitaID"] = new SelectList(_context.EstadoCitas, "EstadoCitaID", "EstadoCitaNombre");
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota");
            ViewData["VeterinarioPrincipalID"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre");
            ViewData["VeterinarioSecundarioID"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitaID,MascotaID,FechaHora,VeterinarioPrincipalID,VeterinarioSecundarioID,Descripcion,Diagnostico,EstadoCitaID")] Cita cita)
        {
            // Validar la duración de la cita
            // Esto asume que todas las citas duran 60 minutos por defecto
            var duracionCita = TimeSpan.FromMinutes(60);

            var tiempoInicioDespues = cita.FechaHora.Add(duracionCita);
            var tiempoInicioAntes = cita.FechaHora.Subtract(duracionCita);

            // Obtiene la fecha actual sin la parte de hora
            var hoy = DateTime.Today;

            // Verifica que la cita no sea para un día anterior al actual
            if (cita.FechaHora.Date < hoy)
            {
                ModelState.AddModelError(string.Empty, "No se pueden agendar citas para días anteriores.");
            }
            // Validación de horario de citas
            if (cita.FechaHora.TimeOfDay < new TimeSpan(7, 0, 0) || cita.FechaHora.TimeOfDay > new TimeSpan(18, 0, 0))
            {
                ModelState.AddModelError(string.Empty, "La cita debe estar entre las 7 am y las 6 pm.");
            }

            // Verificar que la cita sea de lunes a sábado
            if (cita.FechaHora.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError(string.Empty, "Las citas no se pueden agendar los domingos.");
            }

            bool veterinarioOcupado = _context.Citas.Any(c =>
            (c.VeterinarioPrincipalID == cita.VeterinarioPrincipalID || c.VeterinarioSecundarioID == cita.VeterinarioPrincipalID) &&
            ((c.FechaHora < tiempoInicioDespues && c.FechaHora > tiempoInicioAntes) ||
            (c.FechaHora.AddMinutes(60) > cita.FechaHora && c.FechaHora < cita.FechaHora)));

            if (veterinarioOcupado)
            {
                ModelState.AddModelError(string.Empty, "El veterinario ya tiene una cita programada dentro del rango de tiempo seleccionado.");
            }

            // Verificar que el veterinario principal y secundario no sean el mismo
            if (cita.VeterinarioPrincipalID == cita.VeterinarioSecundarioID)
            {
                ModelState.AddModelError(string.Empty, "El veterinario principal y secundario deben ser diferentes.");
            }

            // Verificar que los veterinarios estén activos
            var veterinarioPrincipal = await _context.Set<Usuario>().FindAsync(cita.VeterinarioPrincipalID);
            var veterinarioSecundario = await _context.Set<Usuario>().FindAsync(cita.VeterinarioSecundarioID);
            if (veterinarioPrincipal == null || !veterinarioPrincipal.Estado || veterinarioSecundario == null || !veterinarioSecundario.Estado)
            {
                ModelState.AddModelError(string.Empty, "Uno o ambos veterinarios están inactivos o no existen.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Si llegamos aquí, algo falló, vuelve a cargar el formulario
            //ViewData["EstadoCitaID"] = new SelectList(_context.EstadoCitas, "EstadoCitaID", "EstadoCitaNombre", cita.EstadoCitaID);
            //ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota", cita.MascotaID); // Asegúrate de mostrar un texto adecuado en el dropdown
            //ViewData["VeterinarioPrincipalID"] = new SelectList(_context.Usuarios.Where(u => u.Rol == RolVeterinario), "UsuarioID", "NombreUsuario", cita.VeterinarioPrincipalID);
            //ViewData["VeterinarioSecundarioID"] = new SelectList(_context.Usuarios.Where(u => u.Rol == RolVeterinario), "UsuarioID", "NombreUsuario", cita.VeterinarioSecundarioID);
            ViewData["EstadoCitaID"] = new SelectList(_context.EstadoCitas, "EstadoCitaID", "EstadoCitaNombre");
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota");
            ViewData["VeterinarioPrincipalID"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre");
            ViewData["VeterinarioSecundarioID"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre");
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
            var estadoActualDescripcion = _context.EstadoCitas
    .Where(e => e.EstadoCitaID == cita.EstadoCitaID)
    .Select(e => e.EstadoCitaNombre)
    .FirstOrDefault();

            ViewData["EstadoActualDescripcion"] = estadoActualDescripcion ?? "Estado no definido";
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota", cita.MascotaID);
            ViewData["VeterinarioPrincipalID"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", cita.VeterinarioPrincipalID);
            ViewData["VeterinarioSecundarioID"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", cita.VeterinarioSecundarioID);
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
                return RedirectToAction("Edit", "Citas", new { id = id });
            }
            ViewData["EstadoCitaID"] = new SelectList(_context.EstadoCitas, "EstadoCitaID", "EstadoCitaID", cita.EstadoCitaID);
            ViewData["MascotaID"] = new SelectList(_context.Mascotas, "MascotaID", "NombreMascota", cita.MascotaID);
            ViewData["VeterinarioPrincipalID"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", cita.VeterinarioPrincipalID);
            ViewData["VeterinarioSecundarioID"] = new SelectList(_context.Set<Usuario>(), "Id", "Nombre", cita.VeterinarioSecundarioID);
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
                var estadoCancelado = await _context.EstadoCitas
                                            .FirstOrDefaultAsync(e => e.EstadoCitaNombre == "Cancelada");

                if (estadoCancelado != null)
                {
                    cita.EstadoCita = estadoCancelado;
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Citas.Any(e => e.CitaID == id);
        }
    }
}
