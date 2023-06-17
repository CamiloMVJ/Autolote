using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autolote.Models
{
    public class RegistroVenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int RegistroId { get; set; }
        [Required]

        [ForeignKey("CedulaId")]
        public Cliente? Cliente { get; set; }
        public string? ClienteNombre { get; set; }
        public string CedulaId { get; set; }
        [ForeignKey("VehiculoId")]
        public Vehiculo? Carro { get; set; }
        public int VehiculoId { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Cuota { get; set; }
        public string Capitalizacion { get; set; }
        public decimal TasaInteres { get; set; }
        public int AñosDelContrato { get; set; }

        public RegistroVenta() { }
        public RegistroVenta(Cliente cliente, Vehiculo vehiculo) 
        {
            Cliente = cliente;
            ClienteNombre = cliente.NombreCliente;
            CedulaId = cliente.CedulaId;
            Carro = vehiculo;
            VehiculoId = vehiculo.VehiculoId;
            Monto = vehiculo.Precio;
        }

        public void CalcularCouta(int CantidadDePagos) 
        {
            Cuota = Monto / CantidadDePagos;
        }
    }
}
