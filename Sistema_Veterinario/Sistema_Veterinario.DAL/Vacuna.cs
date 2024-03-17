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
    [Table("Vacuna")]
    public class Vacuna
    {
        [Key]

        public int VacunaId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAplicacion { get; set; }
       
    }
}
