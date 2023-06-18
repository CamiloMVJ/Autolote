namespace Autolote.Models.DTO
{
    public class VehiculoCreateDTO
    {
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }
        public int AñoFab { get; set; }
        public string Color { get; set; }
        public string Descripcion { get; set; }
        public string Chasis { get; set; }

        public bool VerificarDatos()
        {
            if (Marca == "" || Marca == "string" || Estado == "" || Estado == "string" || Color == "" || Color == "string" || Descripcion == "" || Descripcion == "string" ||
                Chasis == "" || Chasis == "string" || Marca == null || Estado == null || Color == null || Descripcion == null || Chasis == null || Precio == 0 || AñoFab == 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
