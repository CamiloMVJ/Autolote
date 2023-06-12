using System.ComponentModel.DataAnnotations.Schema;

namespace Autolote.Models.DTO
{
    public class RegistroVentaCreateDTO
    {
        public string? ClienteNombre { get; set; }
        public string ClienteId { get; set; }
        public string? VehiculoId { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Cuota { get; set; }
        public string Capitalizacion { get; set; }
        public decimal TasaInteres { get; set; }
        public int AñosDelContrato { get; set; }
    }
}
