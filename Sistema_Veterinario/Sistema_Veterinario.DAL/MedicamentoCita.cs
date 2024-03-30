using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    public class MedicamentoCita
    {
        [Key]
        public int MedicamentoCitaID { get; set; }
        public int CitaID { get; set; }
        public int MedicamentoID { get; set; }
        public string Dosis { get; set; }

        // Relaciones
        [ForeignKey("CitaID")]
        public Cita ? Cita { get; set; }
        [ForeignKey("MedicamentoID")]
        public Medicamento ? Medicamento { get; set; }
    }
}
