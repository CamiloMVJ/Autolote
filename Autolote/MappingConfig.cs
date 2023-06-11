using Autolote.Models;
using Autolote.Models.DTO;
using AutoMapper;

namespace Autolote
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<RegistroVenta, RegistroVentaDTO>().ReverseMap();
            CreateMap<Vehiculo, VehiculoDTO>().ReverseMap();
            CreateMap<Vehiculo,VehiculoCreateDTO>().ReverseMap();
            CreateMap<RegistroVenta,RegistroVentaCreateDTO>().ReverseMap();
            CreateMap<Cliente,ClienteCreateDTO>().ReverseMap();
        }
    }
}
