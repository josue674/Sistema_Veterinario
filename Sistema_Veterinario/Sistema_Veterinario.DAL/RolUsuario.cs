using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    public class RolUsuario
    {
        [Key]
        public int RolUsuarioID { get; set; }
        public string NombreRol { get; set; }

        // Relaciones
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
