using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        private bool IsSisAdmin()
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            return userRole == typeof(SisAdmin).Name;
        }

        [HttpPost("Add")]
        public ActionResult<Admin> Add([FromBody] AdminForRequest admin)
        {
            if (!IsSisAdmin())
            {
                return Forbid();
            }
            return Ok(_adminService.Add(admin));
        }

        [HttpGet("{id}")]
        public ActionResult<Admin> GetById([FromRoute] int id)
        {
            if (!IsSisAdmin())
            {
                return Forbid();
            }
            var admin = _adminService.GetById(id);
            if (admin != null)
            {
                return Ok(admin);
            }
            return NotFound();
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Admin>> GetAll()
        {
            if (!IsSisAdmin())
            {
                return Forbid();
            }
            return Ok(_adminService.Get());
        }

        [HttpDelete("[Action]/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!IsSisAdmin())
            {
                return Forbid();
            }
            var admin = _adminService.GetById(id);

            if (admin != null)
            {
                _adminService.Remove(id);
                return NoContent();
            }
            return NotFound();
        }
        [HttpPatch("[Action]")]
        public IActionResult UpdateUsername([FromQuery] string username)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            if (userRole != typeof(Admin).Name)
            {
                return Forbid();
            }
            if (username == null) return BadRequest();
            _adminService.UpdateUsername(userId, username);
            return NoContent();

        }
    }
}
