using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autolote.Models
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string Chasis { get; set; }
        [Required]
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }
        public int AñoFab { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }

    }
}
