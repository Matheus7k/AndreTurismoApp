using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.Models.DTOs;
using AndreTurismoApp.Repositories.Interfaces;
using Dapper;

namespace AndreTurismoApp.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly string _conn;

        public CityRepository()
        {
            _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\API\AndreTurismoApp\AndreTurismoAppDB.mdf";
        }

        public City Create(City city)
        {
            var idCity = 0;

            using(var db = new SqlConnection(_conn))
            {
                idCity = (int)db.ExecuteScalar(City.INSERT, new { city.Description, @DateCreated = DateTime.Now});
            }

            city.Id = idCity;

            return city;
        }

        public List<City> GetCities()
        {
            List<City> citiesList = new();

            using(var db = new SqlConnection(_conn))
            {
                var cities = db.Query<City>(City.GETALL);
                citiesList = (List<City>) cities;
            }

            return citiesList;
        }

        public City GetCityById(int id)
        {
            using(var db = new SqlConnection(_conn))
            {
                var city = db.QueryFirstOrDefault<City>(City.GETBYID, new { @Id = id });
                return city;
            }
        }
    }
}
