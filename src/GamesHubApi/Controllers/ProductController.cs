
using Application.Dtos;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        private bool IsAdmin()
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole == typeof(SisAdmin).Name || userRole == typeof(Admin).Name)
            {
                return true;
            }
            return false;
        }

        [HttpPost("Add")]
        public ActionResult<Product> Add([FromBody] ProductForRequest product)
        {
            
            if (!IsAdmin())
            {
                return Forbid();
            }
            return Ok(_productService.Add(product));
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetById([FromRoute] int id)
        {   if (id < 1)
            {
                return BadRequest();
            }
            var product = _productService.GetById(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }
        [HttpGet("GetAll")]
        public ActionResult<List<Product>> GetAll()
        {
            var products = _productService.Get();
            
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }

        [HttpGet("GetByName")]
        public ActionResult<Product> GetByName([FromQuery] string name)
        {
            
            var product = _productService.GetByName(name);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("[Action]")]
        public ActionResult<List<Product>> GetByType(string type)
        {
            if (type == null) return BadRequest();

            return _productService.GetByType(type);
        }
        [HttpDelete("[Action]/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!IsAdmin())
            {
                return Forbid();
            }
            var product = _productService.GetById(id);

            if (product != null)
            {
                _productService.Remove(id);
                return NoContent();
            }
            return NotFound();

        }
        [HttpPut("Update/{id}")]
        public ActionResult<Product> Update([FromRoute] int id, [FromQuery] ProductForRequest productToUpdate)
        {
            if (!IsAdmin())
            {
                return Forbid();
            }
            var product = _productService.GetById(id);
            if (product != null)
            {
                return Ok(_productService.Update(id, productToUpdate));
            }
            else
            {
                return NotFound();
            }
        }
        
    }
}
