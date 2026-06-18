using AutoMapper;
using GestionGanadera.Application.Dtos.MovimientoLote;
using GestionGanadera.Entities;

namespace GestionGanadera.WebApi.Mapping
{
    public class MovimientoLoteMappingProfile : Profile
    {
        public MovimientoLoteMappingProfile()
        {
            CreateMap<MovimientoLote, MovimientoLoteResponseDto>();
            CreateMap<MovimientoLoteRequestDto, MovimientoLote>();
        }
    }
}

