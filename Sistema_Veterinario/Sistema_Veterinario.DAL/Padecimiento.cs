using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    public class Padecimiento
    {
        [Key]
        public int PadecimientoID { get; set; }
        public int MascotaID { get; set; }
        public string Descripcion { get; set; }

        // Relaciones
        [ForeignKey("MascotaID")]
        public Mascota ? Mascota { get; set; }
    }
}
