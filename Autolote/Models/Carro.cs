using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autolote.Models
{
    public class Carro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CarroId { get; set; }
        [Required]

        public string Marca { get; set; }
        public decimal Precio { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0}\tMarca: {1}\tPrecio: {2}", CarroId, Marca, Precio);
        }

    }
}
