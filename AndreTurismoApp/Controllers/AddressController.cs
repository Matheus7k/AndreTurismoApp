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
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController()
        {
            _addressService = new();
        }

        [HttpGet(Name = "Get Addresses")]
        public Task<List<Address>> GetAddress()
        {
            return _addressService.GetAddress();
        }

        [HttpPost(Name = "Create Address")]
        public Task<Address> CreateAddress(CreateAddressDTO createAddressDTO)
        {
            return _addressService.CreateAddress(createAddressDTO);
        }

        [HttpGet("{id}", Name = "Get Address By Id")]
        public Task<Address> GetAddressById(int id)
        {
            return _addressService.GetAddressById(id);
        }

        [HttpPut("{id}", Name = "Update Address")]
        public Task<HttpStatusCode> UpdateAddress(int id, CreateAddressDTO addressDto)
        {
            return _addressService.UpdateAddress(id, addressDto);
        }

        [HttpDelete("{id}", Name = "Delete Address")]
        public Task<HttpStatusCode> DeleteAddress(int id)
        {
            return _addressService.DeleteAddress(id);
        }
    }
}
