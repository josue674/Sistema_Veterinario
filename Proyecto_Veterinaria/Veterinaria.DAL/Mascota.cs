using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.DAL
{
    [Table("Mascota")]
    public class Mascota
    {
        [Key]
        public int MascotaID { get; set; }

        [Required, MaxLength(100)]
        public string NombreMascota { get; set; }

        [ForeignKey("TipoMascota")]
        public int TipoMascotaId { get; set; }

        [ForeignKey("Raza")]
        public int RazaId { get; set; }

        [ForeignKey("Genero")]
        public int GeneroId { get; set; }

        public int Edad { get; set; }

        public float Peso { get; set; }

        public string UsuarioCreacionId { get; set; }
        public string UsuarioModificacionId { get; set; }
        public string UsuarioDuenoId { get; set; }

        public string ImagenMascota { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public DateTime FechaModificacion { get; set; }

        [Required]
        [DefaultValue("True")]
        public bool Estado { get; set; }

        public Usuario ? UsuarioCreacion { get; set; }
        public Usuario ? UsuarioModificacion { get; set; }
        public Usuario? UsuarioDueno { get; set; }
        public TipoMascota? TipoMascota { get; set; }
        public Raza? Raza { get; set; }
        public Genero? Genr { get; set; }

        public ICollection<Padecimiento> Padecimientos { get; set; } = new List<Padecimiento>();
        public ICollection<DesparasitacionVacuna> DesparasitacionesVacunas { get; set; } = new List<DesparasitacionVacuna>();
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();

    }
}
