using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.Models.DTOs;
using AndreTurismoApp.Repositories;
using AndreTurismoApp.Repositories.Interfaces;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class AddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICityRepository _cityRepository;
        private readonly HttpClient _httpClient = new();

        public AddressService()
        {
            _addressRepository = new AddressRepository();
            _cityRepository = new CityRepository();
        }

        public async Task<Address> Create(Address address)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:5777/api/Addresses/{address.CEP}");
            response.EnsureSuccessStatusCode();

            string addressResponse = await response.Content.ReadAsStringAsync();
            var addressDeserialized = JsonConvert.DeserializeObject<AddressDTO>(addressResponse);

            address.Street = addressDeserialized.logradouro;
            address.Neighborhood = addressDeserialized.bairro;
            address.Complement = addressDeserialized.complemento;
            address.City.Description = addressDeserialized.localidade;
            address.City = _cityRepository.Create(address.City);

            return _addressRepository.Create(address);
        }
    }
}
