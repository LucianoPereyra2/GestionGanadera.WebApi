using AutoMapper;
using GestionGanadera.Application;
using GestionGanadera.Application.Dtos.MovimientoLote;
using GestionGanadera.Entities;
using GestionGanadera.Entities.MicrosoftIdentity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestionGanadera.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosLoteController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<MovimientosLoteController> _logger;
        private readonly IApplication<MovimientoLote> _movimientoLote;
        private readonly IApplication<Lote> _lote;
        private readonly IMapper _mapper;

        public MovimientosLoteController(
            ILogger<MovimientosLoteController> logger,
            UserManager<User> userManager,
            IApplication<MovimientoLote> movimientoLote,
            IApplication<Lote> lote,
            IMapper mapper)
        {
            _logger = logger;
            _movimientoLote = movimientoLote;
            _lote = lote;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<MovimientoLoteResponseDto>>(_movimientoLote.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            MovimientoLote movimiento = _movimientoLote.GetById(Id.Value);
            if (movimiento is null) return NotFound();
            return Ok(_mapper.Map<MovimientoLoteResponseDto>(movimiento));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(MovimientoLoteRequestDto movimientoRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (_lote.GetById(movimientoRequestDto.LoteId) is null)
                return BadRequest("El LoteId no existe.");
            var movimiento = _mapper.Map<MovimientoLote>(movimientoRequestDto);
            _movimientoLote.Save(movimiento);
            return Ok(movimiento.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, MovimientoLoteRequestDto movimientoRequestDto)
        {
            if (!Id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            if (_lote.GetById(movimientoRequestDto.LoteId) is null)
                return BadRequest("El LoteId no existe.");
            MovimientoLote movimientoBack = _movimientoLote.GetById(Id.Value);
            if (movimientoBack is null) return NotFound();
            _mapper.Map(movimientoRequestDto, movimientoBack);
            _movimientoLote.Save(movimientoBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            MovimientoLote movimientoBack = _movimientoLote.GetById(Id.Value);
            if (movimientoBack is null) return NotFound();
            _movimientoLote.Delete(movimientoBack.Id);
            return Ok();
        }
    }
}