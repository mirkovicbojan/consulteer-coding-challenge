using MainAPI.Models;
using MainAPI.Services;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginFormController : Controller
    {
        private readonly AuthenticationService _authService;
        private readonly IUserService _userService; 

        private readonly IRoleService _roleService;

        public LoginFormController(AuthenticationService authService, IUserService userService, IRoleService roleService)
        {
            _authService = authService;
            _userService = userService;
            _roleService = roleService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody]LoginDTO user)
        {
            var login = _userService.CredentialCheck(user.email, user.password);
            var role = _roleService.GetOne(login.roleID);
            var token = _authService.Authenticate(login.email, login.password, role);
            return Ok(token);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody]RegisterDTO user)
        {
            bool check = _userService.checkAvailability(user);
            if(!check)
            {
               return BadRequest("User with those credentials already exists.");
            }
            if(user.password != user.passwordConfirmation)
            {
                return BadRequest("Passwords don't match.");
            }
            return Ok(_userService.Save(user));
        }
    }
}