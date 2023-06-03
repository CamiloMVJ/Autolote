using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autolote.Models
{
    public class RegistroContado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int RegistroId { get; set; }
        [Required]

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }
        public string? ClienteNombre { get; set; }
        public string? CedulaId { get; set; }
        [ForeignKey("Chasis")]
        public Vehiculo? Carro { get; set; }
        public string? Chasis { get; set; }
        public decimal? Monto { get; set; }
    }
}
