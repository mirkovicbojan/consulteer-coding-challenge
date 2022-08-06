using MainAPI.Models;
using MainAPI.Services;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly AuthenticationService _authService;
        private readonly IUserService _userService; 

        private readonly IRoleService _roleService;

        public LoginController(AuthenticationService authService, IUserService userService, IRoleService roleService)
        {
            _authService = authService;
            _userService = userService;
            _roleService = roleService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginDTO user)
        {
            var login = _userService.CredentialCheck(user.email, user.password);
            var role = _roleService.GetOne(login.roleID);
            var token = _authService.Authenticate(login.email, login.password, role);
            return Ok(token);
        }
    }
}