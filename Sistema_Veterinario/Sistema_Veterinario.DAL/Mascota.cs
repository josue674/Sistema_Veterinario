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
    [Table("Mascota")]
    public class Mascota
    {
        [Key]

        public int MascotaId { get; set; }
        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public string Genero { get; set; }

        public int Edad { get; set; } 
        public float Peso { get; set; }

        //Imagen
        public bool Estado { get; set; }

        public Cliente? Cliente { get; set; }
        public Veterinario? Veterinario { get; set; }

    }
}
