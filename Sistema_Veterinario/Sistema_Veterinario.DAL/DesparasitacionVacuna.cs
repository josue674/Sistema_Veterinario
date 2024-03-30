using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    public class DesparasitacionVacuna
    {
        [Key]
        public int DesparasitacionVacunaID { get; set; }
        public int MascotaID { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Producto { get; set; }

        // Relaciones
        [ForeignKey("MascotaID")]
        public Mascota ? Mascota { get; set; }
    }
}
