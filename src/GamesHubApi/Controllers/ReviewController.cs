using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IProductService _productService;

        public ReviewController(IReviewService reviewService, IProductService productService)
        {
            _reviewService = reviewService;
            _productService = productService;
        }

        [HttpPost]
        public ActionResult<Review> Add([FromBody] ReviewForRequest reviewDto)
        {
            if (reviewDto == null || string.IsNullOrEmpty(reviewDto.Content) || reviewDto.ProductId < 1)
            {
                return BadRequest();
            }
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != typeof(Client).Name)
                return Forbid();

            if (_productService.GetById(reviewDto.ProductId) == null)
            {
                return NotFound();
            }
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var review = _reviewService.Add(reviewDto, userId);

            return Ok(review);
        }
        [HttpGet("{id}")]
        public ActionResult<Review> GetById([FromRoute] int id)
        {
            var review = _productService.GetById(id);
            if (review != null)
            {
                return Ok(review);
            }
            return NotFound();
        }
    }
}
