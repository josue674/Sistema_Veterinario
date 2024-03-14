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

        public virtual DbSet<Cliente> Clientes
        { get; set; }
        //public virtual DbSet<Publicacion> Publicaciones { get; set; }
        //public virtual DbSet<Comentario> Comentarios { get; set; }
        //public virtual DbSet<Reaccion> Reacciones { get; set; }



    }
}
