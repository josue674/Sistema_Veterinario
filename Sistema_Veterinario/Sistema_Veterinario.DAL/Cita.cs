using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    [Table("Citas")]
    public class Cita
    {
        [Key]
        public int CitaID { get; set; }

        [ForeignKey("Mascota")]
        public int MascotaID { get; set; }

        public DateTime FechaHora { get; set; }

        public string VeterinarioPrincipalID { get; set; }

        public string VeterinarioSecundarioID { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public string Diagnostico { get; set; }

        [Required]
        public int EstadoCitaID { get; set; }

        public Mascota ? Mascota { get; set; }
        public UsuarioApplication ? VeterinarioPrincipal { get; set; }
        public UsuarioApplication ? VeterinarioSecundario { get; set; }
        public EstadoCita ? EstadoCita { get; set; }
        public ICollection<MedicamentoCita> MedicamentosCita { get; set; } = new List<MedicamentoCita>();
    }
}
