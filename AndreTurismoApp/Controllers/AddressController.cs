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

        [HttpPost(Name = "Create Address")]
        public Task<Address> Create(Address address)
        {
            return _addressService.Create(address);
        }
    }
}
