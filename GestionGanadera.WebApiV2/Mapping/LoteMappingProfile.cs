using AutoMapper;
using GestionGanadera.Application.Dtos.Lote;
using GestionGanadera.Entities;

namespace GestionGanadera.WebApi.Mapping
{
    public class LoteMappingProfile : Profile
    {
        public LoteMappingProfile()
        {
            CreateMap<Lote, LoteResponseDto>();
            CreateMap<LoteRequestDto, Lote>();
        }
    }
}
