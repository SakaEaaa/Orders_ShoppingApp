using Microsoft.AspNetCore.Mvc;
using Orders_ShoppingApp.Interfaces;
using Orders_ShoppingApp.Models;

namespace Orders_ShoppingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repository;

        public OrdersController(IOrderRepository repository)
        {

            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _repository.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _repository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = _repository.Add(value);
            return CreatedAtAction("Get", new { id = order.OrderId }, order);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var existingOrder = _repository.GetById(id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            _repository.Remove(id);
            return NoContent();
        }
    }
}
