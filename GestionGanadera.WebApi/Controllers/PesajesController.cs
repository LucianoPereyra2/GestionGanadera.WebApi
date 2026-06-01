using AutoMapper;
using GestionGanadera.Application;
using GestionGanadera.Application.Dtos.Pesaje;
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
    public class PesajesController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<PesajesController> _logger;
        private readonly IApplication<Pesaje> _pesaje;
        private readonly IMapper _mapper;

        public PesajesController(
            ILogger<PesajesController> logger,
            UserManager<User> userManager,
            IApplication<Pesaje> pesaje,
            IMapper mapper)
        {
            _logger = logger;
            _pesaje = pesaje;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            var id = User.FindFirst("Id").Value.ToString();
            var user = _userManager.FindByIdAsync(id).Result;
            if (_userManager.IsInRoleAsync(user, "Administrador").Result)
                return Ok(_mapper.Map<IList<PesajeResponseDto>>(_pesaje.GetAll()));
            return Unauthorized();
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            Pesaje pesaje = _pesaje.GetById(Id.Value);
            if (pesaje is null) return NotFound();
            return Ok(_mapper.Map<PesajeResponseDto>(pesaje));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PesajeRequestDto pesajeRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var pesaje = _mapper.Map<Pesaje>(pesajeRequestDto);
            _pesaje.Save(pesaje);
            return Ok(pesaje.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, PesajeRequestDto pesajeRequestDto)
        {
            if (!Id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            Pesaje pesajeBack = _pesaje.GetById(Id.Value);
            if (pesajeBack is null) return NotFound();
            pesajeBack = _mapper.Map<Pesaje>(pesajeRequestDto);
            _pesaje.Save(pesajeBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            Pesaje pesajeBack = _pesaje.GetById(Id.Value);
            if (pesajeBack is null) return NotFound();
            _pesaje.Delete(pesajeBack.Id);
            return Ok();
        }
    }
}

