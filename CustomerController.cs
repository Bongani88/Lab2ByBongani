using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab2.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerRepository;

        public CustomerController(ICustomer customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            try
            {
                var result = await _customerRepository.Add(customer);

                if (result)
                    return Ok("Customer added successfully");
                else
                    return BadRequest("Failed to add customer");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            try
            {
                var customer = new Customer { customerID = customerId };
                var result = await _customerRepository.Get(customer);

                if (result)
                    return Ok(customer); // Assuming you want to return the customer object
                else
                    return NotFound($"Customer with ID {customerId} not found");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                var result = await _customerRepository.Update(customer);

                if (result)
                    return Ok("Customer updated successfully");
                else
                    return BadRequest("Failed to update customer");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            try
            {
                var customer = new Customer { customerID = customerId };
                var result = await _customerRepository.Delete(customer);

                if (result)
                    return Ok("Customer deleted successfully");
                else
                    return NotFound($"Customer with ID {customerId} not found");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
