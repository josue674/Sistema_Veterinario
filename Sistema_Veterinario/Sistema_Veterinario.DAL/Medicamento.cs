using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("Medicamento")]
    public class Medicamento
    {
        [Key]
        public int IdMedicamento { get; set; }

        public string nombreMedicamento { get; set; }

        public string descripcionMedicamento { get; set; }

        public Tratamiento? Tratamiento { get; set; }
    }
}
