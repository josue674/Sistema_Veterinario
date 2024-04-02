using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Sistema_Veterinario.DAL;

namespace Sistema_Veterinario.Models
{
    public class MascotaCreateViewModel
    {
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

        public string ImagenMascota { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public bool Estado { get; set; }

        public TipoMascota? TipoMascota { get; set; }
        public Raza? Raza { get; set; }
    }
}