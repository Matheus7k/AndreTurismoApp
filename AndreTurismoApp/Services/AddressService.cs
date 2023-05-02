using System.Net;
using AndreTurismoApp.Models;
using AndreTurismoApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class AddressService
    {
        private readonly static HttpClient _addressClient = new();
        private readonly string _linkHost;

        public AddressService()
        {
            _linkHost = "https://localhost:7001/api/Addresses/";
        }

        public async Task<List<Address>> GetAddress()
        {
            HttpResponseMessage response = await _addressClient.GetAsync(_linkHost);
            response.EnsureSuccessStatusCode();

            string addressResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Address>>(addressResponse);            
        }

        public async Task<Address> CreateAddress(CreateAddressDTO createAddressDTO)
        {
            JsonContent request = JsonContent.Create(createAddressDTO);
            HttpResponseMessage response = await _addressClient.PostAsync(_linkHost, request);
            response.EnsureSuccessStatusCode();

            string addressResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Address>(addressResponse);
        }

        public async Task<Address> GetAddressById(int id)
        {
            HttpResponseMessage response = await _addressClient.GetAsync(_linkHost + id);
            response.EnsureSuccessStatusCode();

            string addressResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Address>(addressResponse);
        }

        public async Task<Address> GetAddressCEP(string cep)
        {
            HttpResponseMessage respondeAddress = await _addressClient.GetAsync($"{_linkHost}cep/{cep}");
            respondeAddress.EnsureSuccessStatusCode();

            string address = await respondeAddress.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Address>(address);
        }

        public async Task<HttpStatusCode> UpdateAddress(int id, CreateAddressDTO addressDto)
        {
            HttpResponseMessage respondeAddress = await _addressClient.GetAsync($"{_linkHost}cep/{addressDto.CEP}");
            respondeAddress.EnsureSuccessStatusCode();

            string address = await respondeAddress.Content.ReadAsStringAsync();
            var fullAddress = JsonConvert.DeserializeObject<Address>(address);

            fullAddress.Number = addressDto.Number;

            JsonContent request = JsonContent.Create(fullAddress);

            HttpResponseMessage response = await _addressClient.PutAsync(_linkHost + id, request);

            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteAddress(int id)
        {
            HttpResponseMessage response = await _addressClient.DeleteAsync(_linkHost + id);

            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }
    }
}
