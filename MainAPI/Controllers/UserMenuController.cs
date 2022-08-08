using System.Security.Claims;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMenuController : Controller
    {
        public readonly IUserService _userService;

        public readonly IHttpContextAccessor _accessor;

        public UserMenuController(IUserService userService, IHttpContextAccessor accessor)
        {
            _userService = userService;
            _accessor = accessor;
        }

        [Authorize(Policy = "canViewAllUsers")]
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAll());
        }

        [Authorize]
        [HttpGet]
        [Route("GetCurrentUser")]
        public IActionResult GetCurrentUser()
        {
            var userEmail = _accessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            return Ok(_userService.GetCurrentUser(userEmail));
        }
    }
}