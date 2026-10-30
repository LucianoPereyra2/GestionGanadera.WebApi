using AutoMapper;
using GestionGanadera.Application;
using GestionGanadera.Application.Dtos.Lote;
using GestionGanadera.Entities;
using GestionGanadera.Entities.MicrosoftIdentity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionGanadera.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class LotesController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<LotesController> _logger;
        private readonly IApplication<Lote> _lote;
        private readonly IApplication<Cliente> _cliente;
        private readonly IApplication<EspecieAnimal> _especie;
        private readonly IMapper _mapper;

        public LotesController(
            ILogger<LotesController> logger,
            UserManager<User> userManager,
            IApplication<Lote> lote,
            IApplication<Cliente> cliente,
            IApplication<EspecieAnimal> especie,
            IMapper mapper)
        {
            _logger = logger;
            _lote = lote;
            _cliente = cliente;
            _especie = especie;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<LoteResponseDto>>(_lote.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            Lote lote = _lote.GetById(Id.Value);
            if (lote is null) return NotFound();
            return Ok(_mapper.Map<LoteResponseDto>(lote));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(LoteRequestDto loteRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (_cliente.GetById(loteRequestDto.ClienteId) is null)
                return BadRequest("El ClienteId no existe.");
            if (_especie.GetById(loteRequestDto.EspecieAnimalId) is null)
                return BadRequest("El EspecieAnimalId no existe.");
            var lote = _mapper.Map<Lote>(loteRequestDto);
            _lote.Save(lote);
            return Ok(lote.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, LoteRequestDto loteRequestDto)
        {
            if (!Id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            if (_cliente.GetById(loteRequestDto.ClienteId) is null)
                return BadRequest("El ClienteId no existe.");
            if (_especie.GetById(loteRequestDto.EspecieAnimalId) is null)
                return BadRequest("El EspecieAnimalId no existe.");
            Lote loteBack = _lote.GetById(Id.Value);
            if (loteBack is null) return NotFound();
            _mapper.Map(loteRequestDto, loteBack);
            _lote.Save(loteBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            Lote loteBack = _lote.GetById(Id.Value);
            if (loteBack is null) return NotFound();
            try
            {
                _lote.Delete(loteBack.Id);
                return Ok();
            }
            catch (DbUpdateException)
            {
                return Conflict("No se puede borrar el lote porque tiene registros asociados (pesajes o movimientos).");
            }
        }
    }
}