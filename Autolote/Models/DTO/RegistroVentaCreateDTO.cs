using System.ComponentModel.DataAnnotations.Schema;

namespace Autolote.Models.DTO
{
    public class RegistroVentaCreateDTO
    {
        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }
        public string? ClienteNombre { get; set; }
        public string CedulaId { get; set; }
        [ForeignKey("VehiculoId")]
        public Vehiculo? Carro { get; set; }
        public string? VehiculoId { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Cuota { get; set; }
        public string Capitalizacion { get; set; }
        public decimal TasaInteres { get; set; }
        public int AñosDelContrato { get; set; }
    }
}
