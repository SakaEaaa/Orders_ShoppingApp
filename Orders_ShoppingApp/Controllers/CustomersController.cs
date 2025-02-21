using Microsoft.AspNetCore.Mvc;
using Orders_ShoppingApp.Interfaces;
using Orders_ShoppingApp.Models;

namespace Orders_ShoppingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {

            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _repository.GetCustomers();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _repository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = _repository.Add(value);
            return CreatedAtAction("Get", new { id = customer.CustomerId }, customer);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var existingCustomer = _repository.GetById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            _repository.Remove(id);
            return NoContent();
        }
    }


}
