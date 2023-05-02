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
    public class PackageController : ControllerBase
    {
        private readonly PackageService _packageService;
        private readonly HotelService _hotelService;
        private readonly TicketService _ticketService;
        private readonly CustomerService _customerService;

        public PackageController()
        {
            _packageService = new();
            _hotelService = new();
            _ticketService = new();
            _customerService = new();
        }

        [HttpGet(Name = "Get Packages")]
        public Task<List<Package>> GetPackages()
        {
            return _packageService.GetPackages();
        }

        [HttpPost(Name = "Create Package")]
        public Task<Package> CreatePackage(CreatePackageDTO packageDTO)
        {
            Hotel hotel = _hotelService.GetHotelId(packageDTO.HotelId).Result;
            Ticket ticket = _ticketService.GetTicketId(packageDTO.TicketId).Result;
            Customer customer = _customerService.GetCustomerId(packageDTO.CustomerId).Result;

            Package package = new()
            {
                Hotel = hotel,
                Ticket = ticket,
                Customer = customer,
                DateCreated = DateTime.Now,
                Price = packageDTO.Price
            };

            return _packageService.CreatePackage(package);
        }

        [HttpGet("{id}", Name = "Get Package By Id")]
        public Task<Package> GetPackageId(int id)
        {
            return _packageService.GetPackageId(id);
        }

        [HttpPut("{id}", Name = "Update Package")]
        public Task<HttpStatusCode> UpdatePackage(int id, Package package)
        {
            return _packageService.UpdatePackage(id, package);
        }

        [HttpDelete("{id}", Name = "Delete Package")]
        public Task<HttpStatusCode> DeletePackage(int id)
        {
            return _packageService.DeletePackage(id);
        }
    }
}
