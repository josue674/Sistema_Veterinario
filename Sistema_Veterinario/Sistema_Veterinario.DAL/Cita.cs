using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    public class Cita
    {
        [Key]
        public int CitaID { get; set; }
        public int MascotaID { get; set; }
        public DateTime FechaHora { get; set; }
        public int VeterinarioPrincipalID { get; set; }
        public int VeterinarioSecundarioID { get; set; }
        public string Descripcion { get; set; }
        public string Diagnostico { get; set; }
        public string Estado { get; set; }

        // Relaciones
        [ForeignKey("MascotaID")]
        public  Mascota ? Mascota { get; set; }
        [ForeignKey("VeterinarioPrincipalID")]
        public  Usuario ? VeterinarioPrincipal { get; set; }
        [ForeignKey("VeterinarioSecundarioID")]
        public  Usuario ? VeterinarioSecundario { get; set; }
        public ICollection<MedicamentoCita> MedicamentosCita { get; set; }
    }
}
