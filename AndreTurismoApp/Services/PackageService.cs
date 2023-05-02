using System.Net;
using AndreTurismoApp.Models;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class PackageService
    {
        private readonly static HttpClient _packageClient = new();
        private readonly string _linkHost;

        public PackageService()
        {
            _linkHost = "https://localhost:7006/api/Packages/";
        }

        public async Task<List<Package>> GetPackages()
        {
            HttpResponseMessage response = await _packageClient.GetAsync(_linkHost);
            response.EnsureSuccessStatusCode();

            string packageResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Package>>(packageResponse);
        }

        public async Task<Package> CreatePackage(Package package)
        {
            JsonContent request = JsonContent.Create(package);
            HttpResponseMessage response = await _packageClient.PostAsync(_linkHost, request);
            response.EnsureSuccessStatusCode();

            string packageResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Package>(packageResponse);
        }

        public async Task<Package> GetPackageId(int id)
        {
            HttpResponseMessage response = await _packageClient.GetAsync(_linkHost + id);
            response.EnsureSuccessStatusCode();

            string packageResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Package>(packageResponse);
        }

        public async Task<HttpStatusCode> UpdatePackage(int id, Package package)
        {
            JsonContent request = JsonContent.Create(package);
            HttpResponseMessage response = await _packageClient.PutAsync(_linkHost + id, request);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeletePackage(int id)
        {
            HttpResponseMessage response = await _packageClient.DeleteAsync(_linkHost + id);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }
    }
}
