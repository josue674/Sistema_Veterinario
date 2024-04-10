using Microsoft.EntityFrameworkCore;
using Veterinaria.DAL;

namespace Veterinaria.DAL
{
    public class VeterinariaDbContext : DbContext
    {
        public VeterinariaDbContext() { }

        public VeterinariaDbContext(DbContextOptions<VeterinariaDbContext> option ) : base( option ) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer();
        }

        public virtual DbSet<Mascota> Mascotas { get; set; }
        public virtual DbSet<TipoMascota> TiposMascota { get; set; }
        public virtual DbSet<Raza> Razas { get; set; }
        public virtual DbSet<Padecimiento> Padecimientos { get; set; }
        public virtual DbSet<Cita> Citas { get; set; }
        public virtual DbSet<DesparasitacionVacuna> DesparasitacionVacunas { get; set; }
        public virtual DbSet<Medicamento> Medicamentos { get; set; }
        public virtual DbSet<MedicamentoCita> MedicamentoCitas { get; set; }
        public virtual DbSet<EstadoCita> EstadoCitas { get; set; }

    }
}
