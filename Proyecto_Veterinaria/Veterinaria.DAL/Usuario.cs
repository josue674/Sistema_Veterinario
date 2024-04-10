using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Veterinaria.DAL
{
    [Table("AspNetUsers")]
    public class Usuario : IdentityUser
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

        public byte[] ImagenUsuario { get; set; }
        public DateTime UltimaConexion { get; set; }
    }
}
