using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.Models.DTOs;

namespace AndreTurismoApp.Repositories.Interfaces
{
    public interface ICityRepository
    {
        City Create(City city);
        List<City> GetCities();
        City GetCityById(int id);
    }
}
