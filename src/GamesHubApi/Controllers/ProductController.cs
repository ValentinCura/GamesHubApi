
using Application.Dtos;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        public ActionResult<Product> GetById([FromRoute] int id)
        {
            var product = _productService.GetById(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }
        [HttpGet("all/products")]
        public ActionResult<List<Product>> GetAll()
        {
            var products = _productService.Get();
            
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }

        [HttpGet("product/name/")]
        public ActionResult<Product> GetByName([FromQuery] string name)
        {
            var product = _productService.GetByName(name);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public ActionResult<Product> Add([FromBody]ProductForRequest product) 
        {
            return Ok(_productService.Add(product));
        }
        [HttpDelete("[Action]/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var product = _productService.GetById(id);

            if (product != null)
            {
                _productService.Remove(id);
                return NoContent();
            }
                return NotFound();
            
        }
        [HttpPut("Update/{id}")]
        public ActionResult Update([FromRoute] int id, [FromQuery] ProductForRequest productToUpdate)
        {
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
