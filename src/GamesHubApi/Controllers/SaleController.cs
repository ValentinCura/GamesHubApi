using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly IClientService _clientService;
        public SaleController(ISaleService saleService, IClientService clientService)
        {
            _saleService = saleService;
            _clientService = clientService;
        }
        [HttpPost]
        public ActionResult<Sale> Add([FromBody] SaleForRequest saleDto)
        {
            if (saleDto == null)
            {
                return BadRequest("Some fields are missing or invalid.");
            }
            var client = _clientService.GetById(saleDto.ClientId);
            if (client != null)
            {
                var sale = new Sale()
                {
                    //ClientId = int.Parse(Client.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    ClientId = client.Id
                };
                return _saleService.Add(sale);
            }
            return NotFound();
        }
    }
}
