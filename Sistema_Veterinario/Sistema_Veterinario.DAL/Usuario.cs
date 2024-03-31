using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required, MaxLength(255)]
        public string NombreUsuario { get; set; }

        [Required]
        public string Contraseña { get; set; }

        [ForeignKey("Rol")]
        public int RolID { get; set; }

        public string ImagenUsuario { get; set; }

        public DateTime UltimaConexion { get; set; }

        public bool Estado { get; set; }

        public Rol ? Rol { get; set; }

        public virtual ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
    }
}
