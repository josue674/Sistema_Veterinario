using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("MascotaUsuarioAcciones")]
    public class MascotaUsuarioAccion
    {
        [Key]
        [ForeignKey("Mascota")]
        public int MascotaId { get; set; }

        public string UsuarioCreacionId { get; set; }

        public string UsuarioModificacionId { get; set; }

        public UsuarioApplication? UsuarioCreacion { get; set; }
        public UsuarioApplication? UsuarioModificacion { get; set; }
        public Mascota? Mascota { get; set; }

    }
}
