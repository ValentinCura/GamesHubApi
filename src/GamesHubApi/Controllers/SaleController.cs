using Application.Dtos;
using Application.Interfaces;
using Application.Services;
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
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpPost("Add")]
        public ActionResult<Sale> Add()
        {
            
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != typeof(Client).Name)
                return Forbid();

            
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var sale = _saleService.Add( userId );

            return Ok(sale);
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
