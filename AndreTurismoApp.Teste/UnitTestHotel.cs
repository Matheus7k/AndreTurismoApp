using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.CustomerService.Data;
using AndreTurismoApp.HotelService.Controllers;
using AndreTurismoApp.HotelService.Data;
using AndreTurismoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AndreTurismoApp.Teste
{
    public class UnitTestHotel
    {
        private DbContextOptions<AndreTurismoAppHotelServiceContext> options;

        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismoAppHotelServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismoAppHotelServiceContext(options))
            {
                context.Hotel.Add(new Hotel { Name = "Teste 1", Price = 1001, Address = new Address { Id = 1, Street = "Street 1", CEP = "123456789", Number = 181, Neighborhood = "Teste 1", Complement = "Teste 1", City = new City() { Id = 1, Description = "City1" } } });
                context.Hotel.Add(new Hotel { Name = "Teste 2", Price = 1002, Address = new Address { Id = 2, Street = "Street 2", CEP = "123456789", Number = 182, Neighborhood = "Teste 2", Complement = "Teste 2", City = new City() { Id = 2, Description = "City2" } } });
                context.Hotel.Add(new Hotel { Name = "Teste 3", Price = 1003, Address = new Address { Id = 3, Street = "Street 3", CEP = "123456789", Number = 183, Neighborhood = "Teste 3", Complement = "Teste 3", City = new City() { Id = 3, Description = "City3" } } });
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppHotelServiceContext(options))
            {
                HotelsController hotelController = new(context);
                IEnumerable<Hotel> hotels = hotelController.GetHotel().Result.Value;
                Assert.Equal(3, hotels.Count());
            }
        }

        [Fact]
        public void GetById()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppHotelServiceContext(options))
            {
                HotelsController hotelController = new(context);
                Hotel hotelResponse = hotelController.GetHotel(1).Result.Value;
                Assert.Equal(1, hotelResponse.Id);
            }
        }

        [Fact]
        public void Create()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppHotelServiceContext(options))
            {
                Hotel hotel = new()
                {
                    Name = "Teste 4",
                    Address = new Address
                    {
                        Street = "Street 4",
                        CEP = "123456789",
                        Number = 184,
                        Neighborhood = "Teste 4",
                        Complement = "Teste 4",
                        City = new City()
                        {
                            Description = "City4"
                        }
                    },
                    Price = 1004,
                };

                HotelsController hotelController = new(context);
                Hotel hotelResponse = hotelController.PostHotel(hotel).Result.Value;
                Assert.Equal(4, hotelResponse.Id);
            }
        }

        [Fact]
        public void Update()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppHotelServiceContext(options))
            {
                Hotel hotel = new()
                {
                    Id = 3,
                    Name = "Teste 4",
                    Price = 1004,
                    Address = new Address
                    {
                        Id = 3,
                        Street = "Street 4",
                        CEP = "123456789",
                        Number = 184,
                        Neighborhood = "Teste 4",
                        Complement = "Teste 4",
                        City = new City()
                        {
                            Id = 3,
                            Description = "City4"
                        }
                    }
                };

                HotelsController hotelController = new(context);
                Hotel hotelResponse = hotelController.PutHotel(3, hotel).Result.Value;
                Assert.Null(hotelResponse);
            }
        }

        [Fact]
        public void Delete()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppHotelServiceContext(options))
            {
                HotelsController hotelController = new(context);
                Hotel hotelResonse = hotelController.DeleteHotel(3).Result.Value;
                Assert.Null(hotelResonse);
            }
        }
    }
}
