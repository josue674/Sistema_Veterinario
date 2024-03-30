using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    public class Raza
    {
        [Key]
        public int RazaID { get; set; }
        public string DescripcionRaza { get; set; }
        public int TipoMascotaID { get; set; }

        // Relaciones
        [ForeignKey("TipoMascotaID")]
        public TipoMascota ? TipoMascota { get; set; }
        public ICollection<Mascota> Mascotas { get; set; }
    }
}
