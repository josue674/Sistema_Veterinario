using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{

    [Table("TipoMascota")]
    public class TipoMascota
    {
        [Key]
        public int IdTipoMascota { get; set; }

        public string tipoMascota { get; set; }


        public Mascota? Mascota { get; set; }
        public ICollection<Raza> Razas { get; set; } = new List<Raza>();

    }
}