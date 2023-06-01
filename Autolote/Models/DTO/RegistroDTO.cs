using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class RegistroDTO
    {
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
        public decimal? Couta { get; set; }

        public override string ToString()
        {
            return string.Format("Registro id: {0}\tSaldo cancelado: {1}\tSaldo por cancelar: {2}\tCuota: {3}", RegistroId, SaldoCancelado, SaldoInsoluto,Couta);
        }
    }
}
