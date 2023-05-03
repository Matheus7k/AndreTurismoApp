using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models.DTOs;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class PostOfficeService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<AddressDTO> GetCep(string cep)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                response.EnsureSuccessStatusCode();

                string addressResponse = await response.Content.ReadAsStringAsync();
                var address = JsonConvert.DeserializeObject<AddressDTO>(addressResponse);

                return address;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

    }
}