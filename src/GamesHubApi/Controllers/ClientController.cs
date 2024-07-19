using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public ActionResult<Client> Add([FromBody] ClientForRequest clientDto)
        {
            return Ok(_clientService.Add(clientDto));
        }
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Client> GetById([FromRoute] int id)
        {
            var client = _clientService.GetById(id);
            if (client != null)
            {
                return Ok(client);
            }
            return NotFound();
        }
        [Authorize]

        [HttpGet("all/clients")]
        public ActionResult<List<Client>> GetAll()
        {
            return Ok(_clientService.Get());
        }
        [Authorize]

        [HttpDelete("[Action]/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var client = _clientService.GetById(id);

            if (client != null)
            {
                _clientService.Remove(id);
                return NoContent();
            }
            return NotFound();

        }
    }
}
