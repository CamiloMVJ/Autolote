﻿using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class RegistroVentaUpdateDTO
    {
        [Required]
        public int RegistroId { get; set; }
        [Required]
        public string? ClienteNombre { get; set; }
        [Required]
        public string? ClienteId { get; set; }
        [Required]
        public string? VehiculoId { get; set; }
        [Required]
        public decimal? Monto { get; set; }
        [Required]
        public decimal? Cuota { get; set; }
        [Required]
        public string? Capitalizacion { get; set; }
        [Required]
        public decimal TasaInteres { get; set; }
        [Required]
        public int AñosDelContrato { get; set; }
    }
}
