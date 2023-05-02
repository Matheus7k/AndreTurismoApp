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
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;
        private readonly AddressService _addressService;
        private readonly CustomerService _customerService;

        public TicketController()
        {
            _ticketService = new();
            _addressService = new();
            _customerService = new();
        }

        [HttpGet(Name = "Get Tickets")]
        public Task<List<Ticket>> GetTickets()
        {
            return _ticketService.GetTickets();
        }

        [HttpPost(Name = "Create Ticket")]
        public Task<Ticket> CreateTicket(CreateTicketDTO ticketDto)
        {
            Address addressOrigin = _addressService.GetAddressCEP(ticketDto.Origin.CEP).Result;
            Address addressDestination = _addressService.GetAddressCEP(ticketDto.Destination.CEP).Result;
            Customer customer = _customerService.GetCustomerId(ticketDto.CustomerId).Result;
             
            
            customer.Id = 0;
            customer.Address.Id = 0;
            customer.Address.City.Id = 0;
            

            addressOrigin.Number = ticketDto.Origin.Number;
            addressDestination.Number = ticketDto.Origin.Number;

            Ticket ticket = new()
            {
                Origin = addressOrigin,
                Destination = addressDestination,
                Customer = customer,
                Date = DateTime.Now,
                Price = ticketDto.Price,
            };

            return _ticketService.CreateTicket(ticket);
        }

        [HttpGet("{id}", Name = "Get Ticket By Id")]
        public Task<Ticket> GetTicketId(int id)
        {
            return _ticketService.GetTicketId(id);
        }

        [HttpPut("{id}", Name = "Update Ticket")]
        public Task<HttpStatusCode> UpdateTickect(int id, Ticket ticket)
        {
            return _ticketService.UpdateTicket(id, ticket);
        }

        [HttpDelete("{id}", Name = "Delete ticket")]
        public Task<HttpStatusCode> DeleteTicket(int id)
        {
            return _ticketService.DeleteTicket(id);
        }
    }
}
