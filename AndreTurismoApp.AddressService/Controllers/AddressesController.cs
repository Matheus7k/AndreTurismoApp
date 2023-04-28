using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.AddressService.Data;
using AndreTurismoApp.Models;
using AndreTurismoApp.Models.DTOs;
using Newtonsoft.Json;

namespace AndreTurismoApp.AddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly HttpClient _httpClient = new();

        // GET: api/Addresses/14840000
        [HttpGet("{cep}")]
        public async Task<AddressDTO> GetAddress(string cep)
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
