using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("DesparasitacionVacunas")]
    public class DesparasitacionVacuna
    {
        [Key]
        public int DesparasitacionVacunaID { get; set; }

        [ForeignKey("Mascota")]
        public int MascotaID { get; set; }

        [Required]
        public string Tipo { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public string Producto { get; set; }

        public Mascota ? Mascota { get; set; }
    }
}
