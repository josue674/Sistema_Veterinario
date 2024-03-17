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
    [Table("Medicamento")]
    public class Medicamento
    {
        [Key]

        public int MedicamentoId { get; set; }
        public string NombreMedicamento { get; set; }

    }
}
