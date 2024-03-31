using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Sistema_Veterinario.DAL
{
    public class Sistema_VeterinarioDbContext : DbContext
    {

        public Sistema_VeterinarioDbContext() { }

        public Sistema_VeterinarioDbContext(DbContextOptions<Sistema_VeterinarioDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer();
        }

        public virtual DbSet<Mascota> Mascotas { get; set; }
        public virtual DbSet<TipoMascota> TiposMascota { get; set; }
        public virtual DbSet<Raza> Razas { get; set; }
        public virtual DbSet<Padecimiento> Padecimientos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Cita> Citas { get; set; }
        public virtual DbSet<DesparasitacionVacuna> DesparasitacionVacunas { get; set; }
        public virtual DbSet<Medicamento> Medicamentos { get; set; }
        public virtual DbSet<MedicamentoCita> MedicamentoCitas { get; set; }
        public virtual DbSet<EstadoCita> EstadoCitas { get; set; }
        public virtual DbSet<MascotaUsuarioAccion> MascotaUsuarioAcciones { get; set; }






    }
}
