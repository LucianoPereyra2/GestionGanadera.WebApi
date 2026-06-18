using AutoMapper;
using GestionGanadera.Application.Dtos.Sector;
using GestionGanadera.Entities;

namespace GestionGanadera.WebApi.Mapping
{
    public class SectorMappingProfile : Profile
    {
        public SectorMappingProfile() 
        {
            CreateMap<Sector, SectorResponseDto>();
            CreateMap<SectorRequestDto, Sector>();
        }   
    }
}

