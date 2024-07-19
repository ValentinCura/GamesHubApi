using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public ActionResult<Admin> Add([FromBody] AdminForRequest admin)
        {
            return Ok(_adminService.Add(admin));
        }

        [HttpGet("{id}")]
        public ActionResult<Admin> GetById([FromRoute]int id)
        {
            var admin = _adminService.GetById(id);
            if (admin != null)
            {
                return Ok(admin);
            }
            return NotFound();
        }

        [HttpGet("all/admins")]
        public ActionResult<List<Admin>> GetAll() 
        { 
            return Ok(_adminService.Get());   
        }

        [HttpDelete("[Action]/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var admin = _adminService.GetById(id);

            if (admin != null)
            {
                _adminService.Remove(id);
                return NoContent();
            }
            return NotFound();

        }

    }
}
