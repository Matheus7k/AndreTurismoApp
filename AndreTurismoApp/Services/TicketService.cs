using System.Net;
using AndreTurismoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class TicketService
    {
        private readonly static HttpClient _ticketClient = new();
        private readonly string _linkHost;

        public TicketService()
        {
            _linkHost = "https://localhost:7005/api/Tickets/";
        }

        public async Task<List<Ticket>> GetTickets()
        {
            HttpResponseMessage response = await _ticketClient.GetAsync(_linkHost);
            response.EnsureSuccessStatusCode();

            string ticketResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Ticket>>(ticketResponse);
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            JsonContent request = JsonContent.Create(ticket);
            HttpResponseMessage response = await _ticketClient.PostAsync(_linkHost, request);
            response.EnsureSuccessStatusCode();

            string ticketResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Ticket>(ticketResponse);
        }

        public async Task<Ticket> GetTicketId(int id)
        {
            HttpResponseMessage response = await _ticketClient.GetAsync(_linkHost + id);
            response.EnsureSuccessStatusCode();

            string ticketResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Ticket>(ticketResponse);
        }

        public async Task<HttpStatusCode> UpdateTicket(int id, Ticket ticket)
        {
            JsonContent request = JsonContent.Create(ticket);
            HttpResponseMessage response = await _ticketClient.PutAsync(_linkHost + id, request);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteTicket(int id)
        {
            HttpResponseMessage response = await _ticketClient.DeleteAsync(_linkHost + id);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }
    }
}
