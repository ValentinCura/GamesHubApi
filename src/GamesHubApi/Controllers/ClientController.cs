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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        private bool IsSisAdmin()
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            return userRole == typeof(SisAdmin).Name;
        }
        [HttpPost("Add")]
        public ActionResult<Client> Add([FromBody] ClientForRequest clientDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                return BadRequest("Cannot register if a client has already loggin.");
            }
            return Ok(_clientService.Add(clientDto));
        }
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Client> GetById([FromRoute] int id)
        {
            if (!IsSisAdmin())
            {
                return Forbid();
            }
            var client = _clientService.GetById(id);
            if (client != null)
            {
                return Ok(client);
            }
            return NotFound();
        }
        [Authorize]

        [HttpGet("GetAll")]
        public ActionResult<List<Client>> GetAll()
        {
            if (!IsSisAdmin())
            {
                return Forbid();
            }
            return Ok(_clientService.Get());
        }
        [Authorize]

        [HttpDelete("[Action]/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!IsSisAdmin())
            {
                return Forbid();
            }
            var client = _clientService.GetById(id);

            if (client != null)
            {
                _clientService.Remove(id);
                return NoContent();
            }
            return NotFound();

        }
        [Authorize]
        [HttpPatch("[Action]")]
        public IActionResult UpdatePassword( [FromQuery] string password)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            if (userRole == typeof(SisAdmin).Name || userRole == typeof(Admin).Name)
            {
                return Forbid();
            }
            if (password == null) return BadRequest();
            _clientService.UpdatePassword(userId, password);
            return NoContent();

        }
    }
}
