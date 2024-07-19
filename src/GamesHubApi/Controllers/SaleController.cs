using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public ActionResult<Sale> Add()

        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            
            if (userId >= 1 || userRole != typeof(Client).Name)
            {
                var client = _clientService.GetById(userId);
                var sale = new Sale()
                {
                    ClientId = userId,
                    Client = client
                   
                };
                return _saleService.Add(sale);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public ActionResult<Sale> GetById([FromRoute] int id)
        {
            var sale= _saleService.GetById(id);
            if (sale != null)
            {
                return Ok(sale);
            }
            return NotFound();
        }
    }
}
