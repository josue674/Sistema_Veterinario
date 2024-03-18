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
    [Table("Usuario")]
    public class Usuario
    {
        [Key]

        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido")]
        [DisplayName("Email")]
        public DateTime FechaRegistro { get; set; }
        [DefaultValue(false)]
        public bool Activo { get; set; }

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}
