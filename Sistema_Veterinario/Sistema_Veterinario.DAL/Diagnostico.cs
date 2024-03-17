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
    [Table("Diagnostico")]
    public class Diagnostico
    {
        [Key]

        public int DiagnosticoId { get; set; }
        public string NombreDiagnostico { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDiagnostico { get; set; }
        
        
    }
}
