using MainAPI.Models;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [Route("api/RoleMenu")]
    [ApiController]
    public class RoleController : Controller
    {
        public readonly IRoleService _roleService;
        public readonly IUserService _userService;

        public RoleController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        [Authorize(Policy = "isAdmin")]
        [HttpPost]
        [Route("AddNewRole")]
        public IActionResult Save(Role obj)
        {
            return Ok(_roleService.Save(obj));
        }

        [Authorize(Policy = "isAdmin")]
        [HttpGet]
        [Route("GetAllRoles")]
        public IActionResult Get()
        {
            return Ok(_roleService.GetAll());
        }

        [Authorize(Policy = "isAdmin")]
        [HttpGet("GetOneRole/{id}")]

        public IActionResult GetOne(Guid id)
        {
            var role = _roleService.GetOne(id);
            if (role == null)
            {
                return BadRequest("Role not found");
            }
            return Ok(role);
        }

        [Authorize(Policy = "isAdmin")]
        [HttpDelete("DeleteRole/{id}")]
        public IActionResult Delete(Guid id)
        {
            var role = _roleService.GetOne(id);
            if (role == null)
            {
                return BadRequest("Role not found");
            }
            _roleService.DeleteOne(id);
            return Ok("Role deleted");
        }

        [Authorize(Policy = "isAdmin")]
        [HttpPut]
        [Route("UpdateRole")]
        public ActionResult<Role> UpdateRole(Role obj)
        {
            var role = _roleService.GetOne(obj.Id);
            if (role == null)
            {
                return BadRequest("Role not found");
            }
            return _roleService.UpdateOne(role);
        }

        [Authorize(Policy = "isAdmin")]
        [HttpPost]
        [Route("UpdateUserRole")]
        public ActionResult<User> UpdateUserRole(UserRoleUpdateDTO obj)
        {
            return Ok(_userService.UpdateRole(obj));
        }
    }
}