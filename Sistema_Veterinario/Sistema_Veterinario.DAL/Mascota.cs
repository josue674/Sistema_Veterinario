using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("Mascotas")]
    public class Mascota
    {
        [Key]
        public int MascotaID { get; set; }

        [Required, MaxLength(100)]
        public string NombreMascota { get; set; }

        [ForeignKey("TipoMascota")]
        public int TipoMascotaID { get; set; }

        [ForeignKey("Raza")]
        public int RazaID { get; set; }

        [Required, MaxLength(10)]
        public string Genero { get; set; }

        public int Edad { get; set; }

        public float Peso { get; set; }

        public string UsuarioCreacionId { get; set; }
        public string UsuarioModificacionId { get; set; }

        public string ImagenMascota { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public bool Estado { get; set; }

        public TipoMascota ? TipoMascota { get; set; }
        public Raza ? Raza { get; set; }
        public UsuarioApplication? UsuarioCreacion { get; set; }
        public UsuarioApplication? UsuarioModificacion { get; set; }


        //public MascotaUsuarioAccion ? MascotaUsuarioAccion { get; set; }

        public ICollection<Padecimiento> Padecimientos { get; set; } = new List<Padecimiento>();
        public ICollection<DesparasitacionVacuna> DesparasitacionesVacunas { get; set; } = new List<DesparasitacionVacuna>();
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}
