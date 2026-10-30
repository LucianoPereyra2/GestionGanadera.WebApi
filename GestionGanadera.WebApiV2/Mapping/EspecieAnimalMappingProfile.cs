using AutoMapper;
using GestionGanadera.Application.Dtos.EspecieAnimal;
using GestionGanadera.Entities;

namespace GestionGanadera.WebApi.Mapping
{
    public class EspecieAnimalMappingProfile : Profile
    {
        public EspecieAnimalMappingProfile()
        {
            CreateMap<EspecieAnimal, EspecieAnimalResponseDto>();
            CreateMap<EspecieAnimalRequestDto, EspecieAnimal>();
        }
    }
}