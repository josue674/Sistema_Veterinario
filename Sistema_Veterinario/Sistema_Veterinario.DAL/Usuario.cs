using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int RolUsuarioID { get; set; }
        public int ImagenUsuario { get; set; }
        public DateTime UltimaConexion { get; set; }
        public bool Estado { get; set; }

        [ForeignKey("RolUsuarioID")]
        public RolUsuario? Rol { get; set; }

        // Relaciones
        public ICollection<Mascota> Mascotas { get; set; }
        //public ICollection<Cita> CitasCreadas { get; set; }
        //public ICollection<Cita> CitasAsignadas { get; set; }
    }
}
