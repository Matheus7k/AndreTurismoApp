using System.Net;
using AndreTurismoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class CustomerService
    {
        private readonly static HttpClient _customerClient = new();
        private readonly string _linkHost;

        public CustomerService()
        {
            _linkHost = "https://localhost:7003/api/Customers/";
        }

        public async Task<List<Customer>> GetCustomers()
        {
            HttpResponseMessage response = await _customerClient.GetAsync(_linkHost);
            response.EnsureSuccessStatusCode();

            string customersResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Customer>>(customersResponse);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            JsonContent request = JsonContent.Create(customer);
            HttpResponseMessage response = await _customerClient.PostAsync(_linkHost, request);
            response.EnsureSuccessStatusCode();

            string customerResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Customer>(customerResponse);
        }

        public async Task<Customer> GetCustomerId(int id)
        {
            HttpResponseMessage response = await _customerClient.GetAsync(_linkHost + id);
            response.EnsureSuccessStatusCode();

            string customerResponse =  await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Customer>(customerResponse);
        }

        public async Task<HttpStatusCode> UpdateCustomer(int id, Customer customer)
        {
            JsonContent request = JsonContent.Create(customer);
            HttpResponseMessage response = await _customerClient.PutAsync(_linkHost + id, request);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteCustomer(int id)
        {
            HttpResponseMessage response = await _customerClient.DeleteAsync(_linkHost + id);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }
    }
}
