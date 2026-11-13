using AutoMapper;
using GestionGanadera.Application.Dtos.Cliente;
using GestionGanadera.Entities;

namespace GestionGanadera.WebApi.Mapping
{
    public class ClienteMappingProfile : Profile
    {
        public ClienteMappingProfile()
        {
            CreateMap<Cliente, ClienteResponseDto>();
            CreateMap<ClienteRequestDto, Cliente>();
            CreateMap<Cliente, ClienteSelectListDto>().ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.RazonSocial));
        }
    }
}

