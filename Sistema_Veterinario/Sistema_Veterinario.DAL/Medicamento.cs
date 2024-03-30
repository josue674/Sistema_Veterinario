using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    public class Medicamento
    {
        [Key]
        public int MedicamentoID { get; set; }
        public string NombreMedicamento { get; set; }
        public string Descripcion { get; set; }

        // Relaciones
        public ICollection<MedicamentoCita> MedicamentosCita { get; set; }
    }
}
