using AutoMapper;
using GestionGanadera.Application.Dtos.Pesaje;
using GestionGanadera.Entities;

namespace GestionGanadera.WebApi.Mapping
{
    public class PesajeMappingProfile : Profile
    {
        public PesajeMappingProfile()
        {
            CreateMap<Pesaje, PesajeResponseDto>();
            CreateMap<PesajeRequestDto, Pesaje>();
        }
    }
}

