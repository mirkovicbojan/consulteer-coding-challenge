using System.Security.Claims;
using MainAPI.Models;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [Route("api/Menu")]
    [ApiController]
    public class UserController : Controller
    {
        public readonly IUserService _userService;

        public readonly IHttpContextAccessor _accessor;

        public UserController(IUserService userService, IHttpContextAccessor accessor)
        {
            _userService = userService;
            _accessor = accessor;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult Get()
        {
            return Ok(_userService.GetAll());
        }
        [Authorize]
        [HttpGet]
        [Route("GetCurrentUsers")]
        public IActionResult GetCurrentUser()
        {
            var userEmail = _accessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            return Ok(_userService.GetCurrentUser(userEmail));
        }
    }
}