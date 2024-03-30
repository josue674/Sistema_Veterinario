using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{

    [Table("Vacuna")]
    public class Vacuna
    {
        [Key]
        public int IdVacuna { get; set; }

        public DateTime fechaVacuna { get; set; }

        public string tipoVacuna { get; set; }

        public String descripcionVacuna { get; set; }

        public Mascota? Mascota { get; set; }
    }
}
