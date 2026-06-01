using AutoMapper;
using GestionGanadera.Application;
using GestionGanadera.Application.Dtos.Cliente;
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
    public class ClientesController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ClientesController> _logger;
        private readonly IApplication<Cliente> _cliente;
        private readonly IMapper _mapper;

        public ClientesController(
            ILogger<ClientesController> logger,
            UserManager<User> userManager,
            IApplication<Cliente> cliente,
            IMapper mapper)
        {
            _logger = logger;
            _cliente = cliente;
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
            {
                return Ok(_mapper.Map<IList<ClienteResponseDto>>(_cliente.GetAll()));
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            Cliente cliente = _cliente.GetById(Id.Value);
            if (cliente is null) return NotFound();
            return Ok(_mapper.Map<ClienteResponseDto>(cliente));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ClienteRequestDto clienteRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var cliente = _mapper.Map<Cliente>(clienteRequestDto);
            _cliente.Save(cliente);
            return Ok(cliente.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, ClienteRequestDto clienteRequestDto)
        {
            if (!Id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            Cliente clienteBack = _cliente.GetById(Id.Value);
            if (clienteBack is null) return NotFound();
            clienteBack = _mapper.Map<Cliente>(clienteRequestDto);
            _cliente.Save(clienteBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            Cliente clienteBack = _cliente.GetById(Id.Value);
            if (clienteBack is null) return NotFound();
            _cliente.Delete(clienteBack.Id);
            return Ok();
        }
    }
}

