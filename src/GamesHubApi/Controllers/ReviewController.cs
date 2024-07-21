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

        [HttpPost("Add")]
        public ActionResult<Review> Add([FromBody] ReviewForRequest reviewDto)
        {
            if (reviewDto.ProductId < 1)
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
        [HttpGet("[Action]/{id}")]
        public ActionResult<List<Review>> GetByProduct([FromRoute] int id) 
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != typeof(Client).Name)
                return Forbid();
            if (id < 1) return BadRequest();
            var product = _productService.GetById(id);
            if (product == null) return NotFound();

            return Ok(_reviewService.GetByProduct(id));
        }
        [HttpPatch("[Action]/{reviewId}")]
        public ActionResult<Review> UpdateContent([FromRoute] int reviewId, [FromBody]string content)
        {
            if (content == null) return BadRequest();
            var userRole = User.Claims.FirstOrDefault(c => c.Type != ClaimTypes.Role)?.Value;
            if (userRole == typeof(Client).Name) return Forbid();

            var review = _reviewService.GetById(reviewId);
            if (review == null) return NotFound();
            if (reviewId < 1) return BadRequest();

            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            return Ok(_reviewService.UpdateContent(userId, reviewId, content));
        }
    }
}
