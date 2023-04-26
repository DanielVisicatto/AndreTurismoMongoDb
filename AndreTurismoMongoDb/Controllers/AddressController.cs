using AndreTurismoMongoDb.Models;
using AndreTurismoMongoDb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly CityService _cityService;
        public AddressController(AddressService addressService, CityService cityService)
        {
            _addressService = addressService;
            _cityService = cityService;
        }

        [HttpGet("/Address")]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet(Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.Get(id);
            if (address == null) return NotFound();
            return Ok(address);
        }

        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            var cityFound = _cityService.GetByName(address.City.Description);
            if (cityFound == null)            
                address.City = _cityService.Create(address.City);            
            else            
                address.City = cityFound;
            
            _addressService.Create(address);
            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<Address> Update(string id, Address address)
        {
            var c = _addressService.Get(id);
            if (c == null) return NotFound();

            _addressService.Update(id, address);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var address = _addressService.Get(id);
            if (address == null) return NotFound();

            _addressService.Delete(id);
            return Ok();
        }
    }
}
