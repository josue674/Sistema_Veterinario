using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.DAL
{
    [Table("Raza")]
    public class Raza
    {
        [Key]
        public int RazaID { get; set; }

        [Required, MaxLength(50)]
        public string DescripcionRaza { get; set; }

        [ForeignKey("TipoMascota")]
        public int TipoMascotaID { get; set; }

        public TipoMascota? TipoMascota { get; set; }
        public ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
    }
}
