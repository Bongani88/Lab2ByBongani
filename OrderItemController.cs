using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Lab2.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItem _orderItemRepository;

        public OrderItemController(IOrderItem orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderItem([FromBody] OrderItem item)
        {
            try
            {
                var result = await _orderItemRepository.Add(item);

                if (result)
                    return Ok("Order item added successfully");
                else
                    return BadRequest("Failed to add order item");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderItems()
        {
            try
            {
                var item = new OrderItem();
                var result = await _orderItemRepository.GetAll(item);

                if (result)
                    return Ok("List of order items retrieved successfully");
                else
                    return NotFound("No order items found");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem([FromBody] OrderItem item)
        {
            try
            {
                var result = await _orderItemRepository.Update(item);

                if (result)
                    return Ok("Order item updated successfully");
                else
                    return BadRequest("Failed to update order item");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteOrderItem(int itemId)
        {
            try
            {
                var item = new OrderItem { orderItemID = itemId };
                var result = await _orderItemRepository.Delete(item);

                if (result)
                    return Ok("Order item deleted successfully");
                else
                    return NotFound($"Order item with ID {itemId} not found");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
