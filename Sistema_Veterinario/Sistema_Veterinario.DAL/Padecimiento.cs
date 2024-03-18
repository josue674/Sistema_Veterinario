using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("Padecimiento")]
    public class Padecimiento
    {
        [Key]

        public int PadecimientoId { get; set; }
        public string NombrePadecimiento { get; set; }

        public ICollection<Padecimiento> Padecimientos { get; set; } = new List<Padecimiento>();

    }
}
