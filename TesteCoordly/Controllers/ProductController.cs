using Microsoft.AspNetCore.Mvc;
using TesteCoordly.Application.Core.Dtos;
using TesteCoordly.Application.Core.Interfaces;

namespace TesteCoordly.Controllers {
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController :ControllerBase {
		private readonly IProductService _productService;

		public ProductController(IProductService productService) {
			_productService = productService;
		}

		// GET: api/products
		[HttpGet]
		public async Task<IActionResult> GetAll() {
			var products = await _productService.GetAll();
			return Ok(products);
		}

		// GET: api/products/{id}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id) {
			var product = await _productService.GetById(id);
			if(product == null) {
				return NotFound();
			}
			return Ok(product);
		}

		// POST: api/products
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ProductDto productDto) {
			if(!ModelState.IsValid) {
				return BadRequest(ModelState);
			}
			var createdProduct = await _productService.Create(productDto); 
			return CreatedAtAction(nameof(GetById), new { id = createdProduct.ProductID }, createdProduct);
		}

		// PUT: api/products
		[HttpPut()]
		public async Task<IActionResult> Update([FromBody] ProductDto productDto) {

			if(!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			var updatedProduct = await _productService.Update(productDto);

			if(updatedProduct == null) {
				return NotFound();
			}

			return Ok(updatedProduct);
		}

		// DELETE: api/products/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id) {
			var isDeleted = await _productService.DeleteById(id);
			if(!isDeleted) {
				return NotFound();
			}
			return NoContent();
		}
	}
}
