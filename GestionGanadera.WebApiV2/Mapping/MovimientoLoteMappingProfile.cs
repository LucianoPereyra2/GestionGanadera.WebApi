using AutoMapper;
using GestionGanadera.Application.Dtos.MovimientoLote;
using GestionGanadera.Entities;

namespace GestionGanadera.WebApi.Mapping
{
    public class MovimientoLoteMappingProfile : Profile
    {
        public MovimientoLoteMappingProfile()
        {
            CreateMap<MovimientoLote, MovimientoLoteResponseDto>().ForMember(dest=>dest.CodigoLote,opt=>opt.MapFrom(src=>src.lote.Codigo));
            CreateMap<MovimientoLoteRequestDto, MovimientoLote>();
        }
    }
}

