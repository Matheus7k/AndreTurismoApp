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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly AddressService _addressService;

        public CustomerController()
        {
            _customerService = new();
            _addressService = new();
        }

        [HttpGet(Name = "Get Customers")]
        public Task<List<Customer>> GetCustomers()
        {
            return _customerService.GetCustomers();
        }

        [HttpPost(Name = "Create Customer")]
        public Task<Customer> Create(CreateCustomerDTO customerDTO)
        {
            Address address = _addressService.GetAddressCEP(customerDTO.CEP).Result;
            address.Number = customerDTO.Number;

            Customer customer = new()
            {
                Name = customerDTO.Name,
                Phone = customerDTO.Phone,
                Address = address,
                DateCreated = DateTime.Now
            };

            return _customerService.CreateCustomer(customer);
        }

        [HttpGet("{id}", Name = "Get Customer By Id")]
        public Task<Customer> GetCustomerById(int id)
        {
            return _customerService.GetCustomerId(id);
        }

        [HttpPut("{id}", Name = "Update Customer")]
        public Task<HttpStatusCode> UpdateCustomer(int id, Customer customer)
        {
            return _customerService.UpdateCustomer(id, customer);
        }

        [HttpDelete("{id}", Name = "Delete Customer")]
        public Task<HttpStatusCode> DeleteCustomer(int id)
        {
            return _customerService.DeleteCustomer(id);
        }
    }
}
