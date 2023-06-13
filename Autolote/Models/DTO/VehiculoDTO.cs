﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class VehiculoDTO
    {

        public int CarroId { get; set; }
        [Required]
        public string Chasis { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public string Estado { get; set; }
        public int AñoFab { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }


    }
}
