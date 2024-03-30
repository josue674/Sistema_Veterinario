using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("Cita")]
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }

        public DateTime fechaCita { get; set; }

        public String descripcionCita { get; set; }

        public Boolean Estado { get; set; }

        public Usuario? Usuario { get; set; }
        public ICollection<Mascota> Mascotas { get; set; } = new List<Mascota>();
        public ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
    }
}
