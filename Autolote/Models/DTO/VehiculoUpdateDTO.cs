using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class VehiculoUpdateDTO
    {
        [Required]
        public int VehiculoId { get; set; }
        [Required]
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }
        public int AñoFab { get; set; }
        public string Color { get; set; }
        public string Descripcion { get; set; }
        public string Chasis { get; set; }
    }
}
