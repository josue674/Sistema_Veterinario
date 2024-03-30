using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        public string nombreUsuario { get; set; }

        public string contrasenna { get; set; }

        public string rol { get; set; }

        public string imagen { get; set; }

        public DateTime ultimaConexion { get; set; }

        public Boolean Estado {  get; set; }

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();


    }
}
