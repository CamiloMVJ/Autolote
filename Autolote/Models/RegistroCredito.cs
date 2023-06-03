using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autolote.Models
{
    public class RegistroCredito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int RegistroId { get; set; }
        [Required]

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }
        public string? ClienteNombre { get; set; }
        public string CedulaId { get; set; }
        [ForeignKey("Chasis")]
        public Vehiculo? Carro { get; set; }
        public string? Chasis { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Cuota { get; set; }
        public string Capitalizacion { get; set; }
        public decimal TasaInteres { get; set; }
        public int AñosDelContrato { get; set; }

        public RegistroCredito() { }
        public RegistroCredito(Cliente cliente, Vehiculo vehiculo) 
        {
            Cliente = cliente;
            ClienteNombre = cliente.NombreCliente;
            CedulaId = cliente.CedulaId;
            Carro = vehiculo;
            Chasis = vehiculo.Chasis;
            Monto = vehiculo.Precio;
        }

        public void CalcularCouta(int CantidadDePagos) 
        {
            Cuota = Monto / CantidadDePagos;
        }
    }
}
