using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.Repositories.Interfaces;
using Dapper;

namespace AndreTurismoApp.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string _conn;

        public AddressRepository()
        {
            _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\API\AndreTurismoApp\AndreTurismoAppDB.mdf";
        }

        public Address Create(Address address)
        {
            var addressId = 0;

            using(var db = new SqlConnection(_conn))
            {
                addressId = db.ExecuteScalar<int>(Address.INSERT, new
                {
                    address.Street,
                    address.Number,
                    address.Neighborhood,
                    address.CEP,
                    address.Complement,
                    address.DateCreated,
                    @IdCity = address.City.Id,
                });
            }

            address.Id = addressId;

            return address;
        }

        public Address GetAddresById(int id)
        {
            string strGetById = $"select a.Id, a.Street, a.Number, a.Neighborhood, a.CEP, a.Complement, a.DateCreated, c.Id, c,Description from Address a join City c on a.IdCity = c.Id where Id = {id}";

            using (var db = new SqlConnection(_conn))
            {
                var addresse = db.Query<Address, City, Address>(strGetById, (address, city) =>
                {
                    address.City = city;
                    return address;
                });

                return (Address)addresse;
            }
        }

        public List<Address> GetAddresses()
        {
            using (var db = new SqlConnection(_conn))
            {
                var addresses = db.Query<Address, City, Address>(Address.GETALL, (address, city) =>
                {
                    address.City = city;
                    return address;
                });

                return (List<Address>)addresses;
            }
        }
    }
}
