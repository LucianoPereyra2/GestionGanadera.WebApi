using AutoMapper;
using GestionGanadera.Application;
using GestionGanadera.Application.Dtos.Empleado;
using GestionGanadera.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionGanadera.WebApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly ILogger<EmpleadosController> _logger;
        private readonly IApplication<Empleado> _empleado;
        private readonly IMapper _mapper;

        public EmpleadosController(
            ILogger<EmpleadosController> logger,
            IApplication<Empleado> empleado,
            IMapper mapper)
        {
            _logger = logger;
            _empleado = empleado;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<EmpleadoResponseDto>>(_empleado.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            Empleado empleado = _empleado.GetById(Id.Value);
            if (empleado is null) return NotFound();
            return Ok(_mapper.Map<EmpleadoResponseDto>(empleado));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(EmpleadoRequestDto empleadoRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var empleado = _mapper.Map<Empleado>(empleadoRequestDto);
            _empleado.Save(empleado);
            return Ok(empleado.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, EmpleadoRequestDto empleadoRequestDto)
        {
            if (!Id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            Empleado empleadoBack = _empleado.GetById(Id.Value);
            if (empleadoBack is null) return NotFound();
            empleadoBack = _mapper.Map<Empleado>(empleadoRequestDto);
            _empleado.Save(empleadoBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            Empleado empleadoBack = _empleado.GetById(Id.Value);
            if (empleadoBack is null) return NotFound();
            _empleado.Delete(empleadoBack.Id);
            return Ok();
        }
    }
}
