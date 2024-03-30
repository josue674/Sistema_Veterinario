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
        public int IdMascota { get; set; }

        public string nombreMascota { get; set; }

        public string genero { get; set; }

        public string edad { get; set; }

        public float peso { get; set; }

        public string Imagen { get; set; }

        public Boolean Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }



        // Se utiliza el "?" para hacerlo nullable y no tener problemas del ModelState
        // public ApplicationUser? UsuarioCreacion { get; set; }
        public ICollection<TipoMascota> Tipos { get; set; } = new List<TipoMascota>();
        public ICollection<Padecimiento> Padecimientos { get; set; } = new List<Padecimiento>();
        public ICollection<Vacuna> Vacunas { get; set; } = new List<Vacuna>();


        public Cita? Cita { get; set;}
    }
}