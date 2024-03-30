using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("Padecimiento")]
    public class Padecimiento
    {
        [Key]
        public int IdPadecimiento { get; set; }

        public string descripcionPadecimiento { get; set; }

        public Mascota? Mascota { get; set; }

    }
}
