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
    public class SaleDetailController : ControllerBase
    {
        private readonly ISaleDetailService _saleDetailService;
        private readonly ISaleService _saleService;
        private readonly IProductService _productService;

        public SaleDetailController (ISaleDetailService saleDetailService, ISaleService saleService, IProductService productService)
        {
            _saleDetailService = saleDetailService;
            _saleService = saleService;
            _productService = productService;
        }

        [HttpPost]
        public ActionResult<SaleDetail> Add([FromBody] SaleDetailForRequest saleDetailDto) 
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole == typeof(SisAdmin).Name || userRole == typeof(Admin).Name)
            {
                return Forbid();
            }

            if (saleDetailDto.Quantity < 1 || saleDetailDto.SaleId < 1 || saleDetailDto.ProductId < 1) return BadRequest();
            if (_saleService.GetById(saleDetailDto.SaleId) == null) return NotFound();
            if (_productService.GetById(saleDetailDto.ProductId) == null) return NotFound();

            return Ok(_saleDetailService.Add(saleDetailDto));
        }
        [HttpGet("[Action]/{saleId}")]
        public ActionResult<List<SaleDetail>> GetBySale([FromRoute] int saleId)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole == typeof(SisAdmin).Name || userRole == typeof(Admin).Name)
            {
                return Forbid();
            }
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            if (saleId < 1) return BadRequest();
            if (_saleService.GetById(saleId) == null) return NotFound();

            return Ok(_saleDetailService.GetBySale(saleId, userId));
        }
        [HttpGet("[Action]")]
        public ActionResult<List<SaleDetail>> GetSaleRecords()
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole == typeof(SisAdmin).Name || userRole == typeof(Admin).Name)
            {
                return Forbid();
            }
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            return _saleDetailService.GetSaleRecords(userId);
        }
    }
}
