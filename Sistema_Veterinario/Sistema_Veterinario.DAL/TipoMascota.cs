using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("TipoMascotas")]
    public class TipoMascota
    {
        [Key]
        public int TipoMascotaID { get; set; }

        [Required, MaxLength(50)]
        public string DescripcionTipo { get; set; }

        public ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
        public ICollection<Raza> Razas { get; set; } = new List<Raza>();
    }
}
