using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class ClienteDTO
    {
        public int ClienteId { get; set; }
        [Required]
        public string ClienteName { get; set;}

        public override string ToString()
        {
            return string.Format("Id Cliente: {0}\tNombre: {1}", ClienteId, ClienteName);
        }
    }
}
