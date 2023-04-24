using AndreTurismoMongoDb.Models;
using AndreTurismoMongoDb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService) => _customerService = customerService;

        [HttpGet("/Customer")]
        public ActionResult<List<Customer>> Get() => _customerService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCustomer")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _customerService.Get(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer customer) => _customerService.Create(customer);

        [HttpPut("{id:length(24)}")]
        public ActionResult<Customer> Update(string id, Customer customer)
        {
            var c = _customerService.Get(id);
            if (c == null) return NotFound();

            _customerService.Update(id, customer);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var customer = _customerService.Get(id);
            if (customer == null) return NotFound();

            _customerService.Delete(id);
            return Ok();
        }
    }
}
