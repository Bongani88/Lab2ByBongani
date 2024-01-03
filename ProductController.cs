using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Lab2.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productRepository;

        public ProductController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            try
            {
                var result = await _productRepository.Add(product);

                if (result)
                    return Ok("Product added successfully");
                else
                    return BadRequest("Failed to add product");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var product = new Product();
                var result = await _productRepository.GetAll(product);

                if (result)
                    return Ok("List of products retrieved successfully");
                else
                    return NotFound("No products found");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            try
            {
                var result = await _productRepository.Update(product);

                if (result)
                    return Ok("Product updated successfully");
                else
                    return BadRequest("Failed to update product");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var product = new Product { productID = productId };
                var result = await _productRepository.Delete(product);

                if (result)
                    return Ok("Product deleted successfully");
                else
                    return NotFound($"Product with ID {productId} not found");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
