using AndreTurismoApp.Models;
using AndreTurismoApp.Models.DTOs;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController()
        {
            _cityService = new();
        }

        [HttpGet(Name = "Get Cities")]
        public ActionResult<List<City>> GetCities()
        {
            return _cityService.GetCities();
        }

        [HttpGet("{id}", Name = "Get City By Id")]
        public ActionResult<City> GetCityById(int id)
        {
            return _cityService.GetCityById(id);
        }

        [HttpPost(Name = "Create City")]
        public ActionResult<City> Create(City city)
        {
            return _cityService.Create(city);
        }
    }
}
