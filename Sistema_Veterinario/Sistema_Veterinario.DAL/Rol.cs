using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("Roles")]
    public class Rol
    {
        [Key]
        public int RolID { get; set; }

        [Required, MaxLength(50)]
        public string Descripcion { get; set; }

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
