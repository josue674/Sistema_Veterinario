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
        public int MascotaID { get; set; }

        [ForeignKey("UsuarioModificacion")]
        public int UsuarioModificacionID { get; set; }

        [ForeignKey("UsuarioCreacion")]
        public int UsuarioCreacionID { get; set; }

        public Usuario? UsuarioCreacion { get; set; }
        public Usuario? UsuarioModificacion { get; set; }

        public Mascota? Mascota { get; set; }

    }
}
