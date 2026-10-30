using AutoMapper;
using GestionGanadera.Application;
using GestionGanadera.Application.Dtos.EspecieAnimal;
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
    public class EspeciesAnimalesController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<EspeciesAnimalesController> _logger;
        private readonly IApplication<EspecieAnimal> _especie;
        private readonly IMapper _mapper;

        public EspeciesAnimalesController(
            ILogger<EspeciesAnimalesController> logger,
            UserManager<User> userManager,
            IApplication<EspecieAnimal> especie,
            IMapper mapper)
        {
            _logger = logger;
            _especie = especie;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<EspecieAnimalResponseDto>>(_especie.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            EspecieAnimal especie = _especie.GetById(Id.Value);
            if (especie is null) return NotFound();
            return Ok(_mapper.Map<EspecieAnimalResponseDto>(especie));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(EspecieAnimalRequestDto especieRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var especie = _mapper.Map<EspecieAnimal>(especieRequestDto);
            _especie.Save(especie);
            return Ok(especie.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, EspecieAnimalRequestDto especieRequestDto)
        {
            if (!Id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            EspecieAnimal especieBack = _especie.GetById(Id.Value);
            if (especieBack is null) return NotFound();
            _mapper.Map(especieRequestDto, especieBack);
            _especie.Save(especieBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            EspecieAnimal especieBack = _especie.GetById(Id.Value);
            if (especieBack is null) return NotFound();
            try
            {
                _especie.Delete(especieBack.Id);
                return Ok();
            }
            catch (DbUpdateException)
            {
                return Conflict("No se puede borrar la especie porque tiene lotes asociados.");
            }
        }
    }
}