using Microsoft.AspNetCore.Mvc;
using ProductApiDemo.Entities.Models;
using ProductApiDemo.Entities.RequestFeatures;
using ProductApiDemo.Services.Contracts;

namespace ProductApiDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] ProductParameters productParameters)
        {
            var products = _service.GetAllProducts(productParameters);
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetProductById(id);

            if (product is null)
                return NotFound($"Product with id {id} was not found.");

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            var createdProduct = _service.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            _service.UpdateProduct(id, product);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteProduct(id);
            return NoContent();
        }
    }
}
