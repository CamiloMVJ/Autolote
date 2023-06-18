using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class VehiculoUpdateDTO
    {
        [Required]
        public int VehiculoId { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public int AñoFab { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Chasis { get; set; }
    }
}
