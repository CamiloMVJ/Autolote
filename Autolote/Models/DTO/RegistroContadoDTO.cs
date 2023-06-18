using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class RegistroContadoDTO
    {
        public int RegistroId { get; set; }
        [Required]

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }
        public string? ClienteNombre { get; set; }
        public int ClienteId { get; set; }
        [ForeignKey("Chasis")]
        public Vehiculo? Carro { get; set; }
        public string? Chasis { get; set; }
        public decimal? Monto { get; set; }
    }
}
