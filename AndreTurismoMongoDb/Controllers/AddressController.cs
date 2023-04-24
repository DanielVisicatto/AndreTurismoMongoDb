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
        public AddressController(AddressService addressService) => _addressService = addressService;

        [HttpGet("/Address")]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.Get(id);
            if (address == null) return NotFound();
            return Ok(address);
        }

        [HttpPost]
        public ActionResult<Address> Create(Address address) => _addressService.Create(address);

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
