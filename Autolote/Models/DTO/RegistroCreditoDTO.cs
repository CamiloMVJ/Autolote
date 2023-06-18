using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autolote.Models.DTO
{
    public class RegistroCreditoDTO
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
        public decimal? Cuota { get; set; }
        public string Capitalizacion { get; set; }
        public decimal TasaInteres { get; set; }
        public int AñosDelContrato { get; set; }

    }
}
