using System.Net;
using AndreTurismoApp.Models;
using AndreTurismoApp.Models.DTOs;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class HotelService
    {
        private readonly static HttpClient _hotelClient = new();
        private readonly string _linkHost;

        public HotelService()
        {
            _linkHost = "https://localhost:7004/api/Hotels/";
        }

        public async Task<List<Hotel>> GetHotels()
        {
            HttpResponseMessage response = await _hotelClient.GetAsync(_linkHost);
            response.EnsureSuccessStatusCode();

            string hotelResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Hotel>>(hotelResponse);
        }

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            JsonContent request = JsonContent.Create(hotel);
            HttpResponseMessage response = await _hotelClient.PostAsync(_linkHost, request);
            response.EnsureSuccessStatusCode();

            string hotelResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Hotel>(hotelResponse);
        }
        
        public async Task<Hotel> GetHotelId(int id)
        {
            HttpResponseMessage response = await _hotelClient.GetAsync(_linkHost + id);
            response.EnsureSuccessStatusCode();

            string hotelResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Hotel>(hotelResponse);
        }

        public async Task<HttpStatusCode> UpdateHotel(int id, Hotel hotel)
        {
            JsonContent request = JsonContent.Create(hotel);
            HttpResponseMessage response = await _hotelClient.PutAsync(_linkHost + id, request);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteHotel(int id)
        {
            HttpResponseMessage response = await _hotelClient.DeleteAsync(_linkHost + id);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }
    }
}
