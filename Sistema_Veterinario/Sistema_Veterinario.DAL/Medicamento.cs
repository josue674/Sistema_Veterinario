using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("Medicamentos")]
    public class Medicamento
    {
        [Key]
        public int MedicamentoID { get; set; }

        [Required, MaxLength(100)]
        public string NombreMedicamento { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; }

        public virtual ICollection<MedicamentoCita> MedicamentosCita { get; set; } = new List<MedicamentoCita>();
    }
}
