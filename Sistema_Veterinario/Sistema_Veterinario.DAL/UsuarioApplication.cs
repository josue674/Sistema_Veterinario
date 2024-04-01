using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("AspNetUsers")]
    public class UsuarioApplication : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string PrimerApellido { get; set; }

        [Required]
        [MaxLength(100)]
        public string SegundoApellido { get; set; }

        [Required]
        [DefaultValue("True")]
        public bool Estado { get; set; }

        public string ImagenUsuario { get; set; }
        public DateTime UltimaConexion { get; set; }
    }
}
