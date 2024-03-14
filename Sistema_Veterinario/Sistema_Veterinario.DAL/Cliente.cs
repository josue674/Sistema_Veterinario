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
    [Table("Cliente")]
    public class Cliente
    {
        [Key]

        public int ClienteId { get; set; }
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido")]
        [DisplayName("Email")]
        public string Apellido { get; set; }
        public DateTime FechaRegistro { get; set; }
        [DefaultValue(false)]
        public bool Activo { get; set; }
    }
}
