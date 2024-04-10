using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.DAL
{
    [Table("MedicamentoCita")]
    public class MedicamentoCita
    {
        [Key]
        public int MedicamentoCitaID { get; set; }

        [ForeignKey("Cita")]
        public int CitaID { get; set; }

        [ForeignKey("Medicamento")]
        public int MedicamentoID { get; set; }

        [Required]
        public int Dosis { get; set; }

        public Cita ? Cita { get; set; }
        public Medicamento ? Medicamento { get; set; }
    }
}
