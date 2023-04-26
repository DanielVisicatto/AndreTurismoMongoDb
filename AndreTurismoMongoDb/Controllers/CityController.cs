using AndreTurismoMongoDb.Models;
using AndreTurismoMongoDb.Services;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;
        public CityController(CityService cityService) => _cityService = cityService;

        [HttpGet("/City")]
        public ActionResult<List<City>> Get() => _cityService.Get();

        [HttpGet(Name = "GetCity")]
        public ActionResult<City>Get(string id)
        {
            var city = _cityService.Get(id);
            if(city == null) return NotFound();
            return Ok(city);
        }

        [HttpPost]
        public ActionResult<City> Create (City city) => _cityService.Create(city);

        [HttpPut("{id:length(24)}")]
        public ActionResult<City> Update (string id, City city)
        {
            var c = _cityService.Get(id);
            if (c == null) return NotFound();

            _cityService.Update(id, city);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var city = _cityService.Get(id);
            if (city == null) return NotFound();

            _cityService.Delete(id);
            return Ok();
        }
    }
}
