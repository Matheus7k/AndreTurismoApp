
using System.Net;
using AndreTurismoApp.Models;
using AndreTurismoApp.Models.DTOs;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        public readonly HotelService _hotelService;
        public readonly AddressService _addressService;

        public HotelController()
        {
            _hotelService = new();
            _addressService = new();
        }

        [HttpGet(Name = "Get Hotels")]
        public Task<List<Hotel>> GetHotels()
        {
            return _hotelService.GetHotels();
        }

        [HttpPost(Name = "Create Hotel")]
        public Task<Hotel> CreateHotel(CreateHotelDTO hotelDto)
        {
            Address address = _addressService.GetAddressCEP(hotelDto.address.CEP).Result;
            address.Number = hotelDto.address.Number;

            Hotel hotel = new()
            {
                Name = hotelDto.Name,
                Price = hotelDto.Price,
                Address = address,
                DateCreated = DateTime.Now
            };

            return _hotelService.CreateHotel(hotel);
        }

        [HttpGet("{id}", Name = "Get Hotel By Id")]
        public Task<Hotel> GetHotelId(int id)
        {
            return _hotelService.GetHotelId(id);
        }

        [HttpPut("{id}", Name = "Update Hotel")]
        public Task<HttpStatusCode> UpdateHotel(int id, Hotel hotel)
        {
            return _hotelService.UpdateHotel(id, hotel);
        }

        [HttpDelete("{id}", Name = "Delete Hotel")]
        public Task<HttpStatusCode> DeleteHotel(int id)
        {
            return _hotelService.DeleteHotel(id);
        }
    }
}
