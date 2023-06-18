using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

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
        public decimal SaldoInsoluto { get; set; }

        public RegistroVenta() { }
        public RegistroVenta(Cliente cliente, Vehiculo vehiculo, string capitalizacion, int añoscontrato)
        {
            Cliente = cliente;
            ClienteNombre = cliente.NombreCliente;
            CedulaId = cliente.CedulaId;
            Carro = vehiculo;
            VehiculoId = vehiculo.VehiculoId;
            Monto = vehiculo.Precio;
            Capitalizacion = capitalizacion;
            AñosDelContrato = añoscontrato;
        }

        public void CalcularCouta()
        {
            int cantidadPagosAnual = 0;
            int cantidadPagos = 0;

            TasaInteres = Convert.ToDecimal(0.20M + 0.05M*(Convert.ToDecimal(AñosDelContrato)));
            cantidadPagosAnual = CalcularPagosAnules();
            cantidadPagos = cantidadPagosAnual * AñosDelContrato;
            double tasa = Convert.ToDouble(TasaInteres);
            //Calculo de la couta
            decimal denominador = Convert.ToDecimal(1 - Math.Pow(1+tasa,-12));
            Cuota = (Monto / denominador) * TasaInteres;

        }

        private int CalcularPagosAnules()
        {
            switch (Capitalizacion)
            {
                case "Mensual":
                    return 12;
                case "Bimestral":
                    return 6;
                case "Trimestral":
                    return 4;
                case "Semestral":
                    return 2;
                case "Anual":
                    return 1;
                default: return 0;
            }
        }

        public bool VerificarDatos()
        {
            if (CedulaId == "" || CedulaId == "string" || VehiculoId == 0 || Capitalizacion == "" || Capitalizacion == "string" || AñosDelContrato == 0
                || CedulaId == null || Capitalizacion == null)
                return true;
            else
                return false;
        }
    }
}
