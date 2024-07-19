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
    public class SaleDetailController : ControllerBase
    {
        private readonly ISaleDetailService _saleDetailService;

        public SaleDetailController (ISaleDetailService saleDetailService)
        {
            _saleDetailService = saleDetailService;
        }

        [HttpPost]
        public ActionResult<SaleDetail> Add(SaleDetailForRequest saleDetailDto) 
        { 
            if (saleDetailDto != null)
            {
                return Ok(_saleDetailService.Add(saleDetailDto));
            }
            return NotFound();
        }
    }
}
