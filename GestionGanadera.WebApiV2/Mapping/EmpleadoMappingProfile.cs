using AutoMapper;
using GestionGanadera.Application.Dtos.Empleado;
using GestionGanadera.Entities;

namespace GestionGanadera.WebApiV2.Mapping
{
    public class EmpleadoMappingProfile : Profile
    {
        public EmpleadoMappingProfile()
        {
            CreateMap<Empleado, EmpleadoResponseDto>();
            CreateMap<EmpleadoRequestDto, Empleado>();

        }



    }
}
