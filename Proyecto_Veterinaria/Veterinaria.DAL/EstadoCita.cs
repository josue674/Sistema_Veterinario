using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.DAL
{
    [Table("EstadoCitas")]
    public class EstadoCita
    {
        [Key]
        public int EstadoCitaID {  get; set; }
        
        public string EstadoCitaNombre { get; set; }

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}
