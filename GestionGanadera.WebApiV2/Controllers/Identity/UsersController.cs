using GestionGanadera.Entities.MicrosoftIdentity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestionGanadera.WebApi.Controllers.Identity
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UsersController> _logger;

        public UsersController(RoleManager<Role> roleManager,
            UserManager<User> userManager,
            ILogger<UsersController> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddRoleToUser")]
        public async Task<IActionResult> Guardar(string userId, string roleId)
        {
            var user = _userManager.FindByIdAsync(userId).Result;
            var role = _roleManager.FindByIdAsync(roleId).Result;
            if (user is not null && role is not null)
            {
                var status = await _userManager.AddToRoleAsync(user, role.Name);
                if (status.Succeeded)
                    return Ok(new { user = user.UserName, rol = role.Name });
            }
            return BadRequest(new { userId = userId, roleId = roleId });
        }
    }
}

