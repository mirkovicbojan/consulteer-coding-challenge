using MainAPI.Models;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Save(UserPostDTO obj)
        {
            return Ok(_userService.Save(obj));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(Guid id)
        {
            User user = _userService.GetOne(id);
            if (user == null)
            {
                return BadRequest("Client not found");
            }
            return Ok(user);
        }
    }
}