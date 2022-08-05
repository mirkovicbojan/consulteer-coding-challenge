using MainAPI.Models;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController:Controller
    {
        public IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public IActionResult Save(Role obj)
        {
            return Ok(_roleService.Save(obj));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_roleService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(Guid id)
        {
            var role = _roleService.GetOne(id);
            if (role == null)
            {
                return BadRequest("Role not found");
            }
            return Ok(role);
        }

        [HttpDelete("{id}")]
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

        [HttpPut]
        public ActionResult<Role> UpdateClient(Role obj)
        {
            var role = _roleService.GetOne(obj.Id);
            if (role == null)
            {
                return BadRequest("Role not found");
            }
            return _roleService.UpdateOne(role);
        }
    }
}