using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("RazaMascota")]
    public class Raza
    {
        [Key]
        public int IdRazaMascota { get; set; }

        public string tipoMascota { get; set; }


        public TipoMascota? TipoMascota { get; set; }
    }
}