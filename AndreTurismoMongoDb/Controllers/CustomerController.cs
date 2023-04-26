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
        private readonly AddressService _addressService;
        private readonly CityService _cityService;
        public CustomerController(CustomerService customerService, AddressService addressService, CityService cityService)
        {
            _addressService = addressService;
            _customerService = customerService;
            _cityService = cityService;
        }

        [HttpGet("/Customer")]
        public ActionResult<List<Customer>> Get() => _customerService.Get();

        [HttpGet(Name = "GetCustomer")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _customerService.Get(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            var cityFound = _cityService.GetByName(customer.Address.City.Description);
            var addressFound = _addressService.GetBy(customer.Address.Street);            

            if( cityFound.Id == null)            
                customer.Address.City = _cityService.Create(customer.Address.City);           
            else            
                customer.Address.City = cityFound;                   
                       
            if (addressFound.Id == null)                           
                customer.Address = _addressService.Create(customer.Address);            
            else            
                customer.Address = addressFound;
            
            _customerService.Create(customer);
            return Ok();
        }

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
