using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Veterinario.DAL
{
    public class Mascota
    {
        [Key]
        public int MascotaID { get; set; }
        public string NombreMascota { get; set; }
        public int TipoMascotaID { get; set; }
        public int RazaID { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public decimal Peso { get; set; }
        public int DueñoID { get; set; }
        public byte[] ImagenMascota { get; set; }
        public int CodigoUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CodigoUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Estado { get; set; }

        //// Relaciones
        [ForeignKey("TipoMascotaID")]
        public TipoMascota ? TipoMascota { get; set; }
        [ForeignKey("RazaID")]
        public Raza ? Raza { get; set; }
        [ForeignKey("DueñoID")]
        public Usuario Dueño { get; set; }
        public ICollection<Padecimiento> Padecimientos { get; set; }
        public ICollection<DesparasitacionVacuna> DesparasitacionesVacunas { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}
