using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Lab2.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderRepository;

        public OrderController(IOrder orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Orders order)
        {
            try
            {
                var result = await _orderRepository.Add(order);

                if (result)
                    return Ok("Order added successfully");
                else
                    return BadRequest("Failed to add order");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var order = new Orders();
                var result = await _orderRepository.GetAll(order);

                if (result)
                    return Ok("List of orders retrieved successfully");
                else
                    return NotFound("No orders found");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] Orders order)
        {
            try
            {
                var result = await _orderRepository.Update(order);

                if (result)
                    return Ok("Order updated successfully");
                else
                    return BadRequest("Failed to update order");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            try
            {
                var order = new Orders { orderID = orderId };
                var result = await _orderRepository.Delete(order);

                if (result)
                    return Ok("Order deleted successfully");
                else
                    return NotFound($"Order with ID {orderId} not found");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
