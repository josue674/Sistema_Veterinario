using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    public class TipoMascota
    {
        [Key]
        public int TipoMascotaID { get; set; }
        public string DescripcionTipo { get; set; }

        // Relaciones
        public ICollection<Mascota> Mascotas { get; set; }
        public ICollection<Raza> Razas { get; set; }
    }
}
