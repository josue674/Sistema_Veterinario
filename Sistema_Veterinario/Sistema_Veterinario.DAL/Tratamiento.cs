using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("Tratamiento")]
    public class Tratamiento
    {
        [Key]
        public int IdTratamiento { get; set; }
        public string descripcionTratamiento { get; set; }
        public string dosis { get; set; }

        public Cita? Cita { get; set; }

        public ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();

    }
}
