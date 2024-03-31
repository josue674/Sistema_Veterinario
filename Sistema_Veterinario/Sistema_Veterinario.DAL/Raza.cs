using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("Razas")]
    public class Raza
    {
        [Key]
        public int RazaID { get; set; }

        [Required, MaxLength(100)]
        public string DescripcionRaza { get; set; }

        [ForeignKey("TipoMascota")]
        public int TipoMascotaID { get; set; }

        public TipoMascota ? TipoMascota { get; set; } 
        public ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
    }
}
