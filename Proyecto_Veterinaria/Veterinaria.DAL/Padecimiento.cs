using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.DAL
{
    [Table("Padecimientos")]
    public class Padecimiento
    {
        [Key]
        public int PadecimientoID { get; set; }

        [ForeignKey("Mascota")]
        public int MascotaID { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public Mascota ? Mascota { get; set; }
    }
}
