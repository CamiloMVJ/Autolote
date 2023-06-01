using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class CarroDTO
    {

        public int CarroId { get; set; }
        [Required]

        public string Marca { get; set; }
        public decimal Precio { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0}\tMarca: {1}\tPrecio: {2}", CarroId,Marca,Precio);
        }
    }
}
