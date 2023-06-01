using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autolote.Models
{
    public class Registro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public const double InteresAnual = 0.18;
        public int RegistroId { get; set; }
        [Required]

        public Cliente? Cliente { get; set; }
        public string? ClienteNombre { get; set; }
        public int ClienteId { get; set; }
        public Carro? Carro { get; set; }
        public string? CarroMarca { get; set; }
        public decimal? CarroPrecio { get; set; }
        public decimal? SaldoInsoluto { get; set; }
        public decimal? SaldoCancelado { get; set; }
        public decimal? Cuota { get; set; }

        public Registro(Cliente cliente, Carro carro)
        {
            Cliente = cliente;
            ClienteNombre = cliente.ClienteNombre;
            ClienteId = cliente.ClienteId;
            Carro = carro;
            CarroMarca = carro.Marca;
            CarroPrecio = carro.Precio;
            SaldoInsoluto = carro.Precio;
            SaldoCancelado = 0;
            Cuota = 0;
        }
        public Registro() { }

        public void PagarCuota(decimal monto)
        {

        }
        public void CalcularCouta(int CantidadDePagos) 
        {
            Cuota = CarroPrecio / CantidadDePagos;
        }
    }
}
