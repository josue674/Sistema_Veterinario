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
    [Table("Cita")]
    public class Cita
    {
        [Key]

        public int CitaId { get; set; }
        public DateTime FechaCita { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
