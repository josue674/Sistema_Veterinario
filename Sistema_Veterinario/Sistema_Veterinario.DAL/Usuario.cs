using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Rol { get; set; } // Considerar enum o tabla separada si se requiere mayor flexibilidad
        public byte[] ImagenUsuario { get; set; }
        public DateTime UltimaConexion { get; set; }
        public bool Estado { get; set; }

        // Relaciones
        public ICollection<Mascota> Mascotas { get; set; }
        //public ICollection<Cita> CitasCreadas { get; set; }
        //public ICollection<Cita> CitasAsignadas { get; set; }
    }
}
