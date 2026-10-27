using AutoMapper;
using GestionGanadera.Application;
using GestionGanadera.Application.Dtos.Sector;
using GestionGanadera.Entities;
using GestionGanadera.Entities.MicrosoftIdentity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestionGanadera.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SectoresController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<SectoresController> _logger;
        private readonly IApplication<Sector> _sector;
        private readonly IMapper _mapper;

        public SectoresController(
            ILogger<SectoresController> logger,
            UserManager<User> userManager,
            IApplication<Sector> sector,
            IMapper mapper)
        {
            _logger = logger;
            _sector = sector;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<SectorResponseDto>>(_sector.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            Sector sector = _sector.GetById(Id.Value);
            if (sector is null) return NotFound();
            return Ok(_mapper.Map<SectorResponseDto>(sector));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(SectorRequestDto sectorRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var sector = _mapper.Map<Sector>(sectorRequestDto);
            _sector.Save(sector);
            return Ok(sector.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, SectorRequestDto sectorRequestDto)
        {
            if (!Id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            Sector sectorBack = _sector.GetById(Id.Value);
            if (sectorBack is null) return NotFound();
            sectorBack = _mapper.Map<Sector>(sectorRequestDto);
            _sector.Save(sectorBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            Sector sectorBack = _sector.GetById(Id.Value);
            if (sectorBack is null) return NotFound();
            _sector.Delete(sectorBack.Id);
            return Ok();
        }
    }
}

