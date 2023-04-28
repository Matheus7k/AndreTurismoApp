using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.Models.DTOs;
using AndreTurismoApp.Repositories;
using AndreTurismoApp.Repositories.Interfaces;

namespace AndreTurismoApp.Services
{
    public class CityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService()
        {
            _cityRepository = new CityRepository();
        }

        public City Create(City city)
        {
            return _cityRepository.Create(city);
        }

        public List<City> GetCities()
        {
            return _cityRepository.GetCities();
        }

        public City GetCityById(int id)
        {
            return _cityRepository.GetCityById(id);
        }
    }
}
