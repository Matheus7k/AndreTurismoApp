using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.AddressService.Data;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;
using AndreTurismoApp.AddressService.Controllers;
using AndreTurismoApp.Services;
using AndreTurismoApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Teste
{
    public class UnitTestAddress
    {
        private DbContextOptions<AndreTurismoAppAddressServiceContext> options;

        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismoAppAddressServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismoAppAddressServiceContext(options))
            {
                context.Address.Add(new Address { Id = 1, Street = "Street 1", CEP = "123456789", Number = 183, Neighborhood = "Teste 1", Complement = "Teste 1", City = new City() { Id = 1, Description = "City1" } });
                context.Address.Add(new Address { Id = 2, Street = "Street 2", CEP = "987654321", Number = 184, Neighborhood = "Teste 2", Complement = "Teste 2", City = new City() { Id = 2, Description = "City2" } });
                context.Address.Add(new Address { Id = 3, Street = "Street 3", CEP = "159647841", Number = 185, Neighborhood = "Teste 3", Complement = "Teste 3", City = new City() { Id = 3, Description = "City3" } });
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAddressServiceContext(options))
            {
                AddressesController addressController = new AddressesController(context, null);
                IEnumerable<Address> clients = addressController.GetAddress().Result.Value;

                Assert.Equal(3, clients.Count());
            }
        }

        [Fact]
        public void GetbyId()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAddressServiceContext(options))
            {
                int clientId = 2;
                AddressesController addressController = new AddressesController(context, null);
                Address client = addressController.GetAddress(clientId).Result.Value;
                Assert.Equal(2, client.Id);
            }
        }

        [Fact]
        public async void Create()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAddressServiceContext(options))
            {
                CreateAddressDTO addressDTO = new()
                {
                    CEP = "14801300",
                    Number = 1001
                };

                AddressesController addressController = new AddressesController(context, new PostOfficeService());
                Address ad = addressController.PostAddress(addressDTO).Result.Value;
                Assert.Equal("Rua São Bento", ad.Street);
            }
        }

        [Fact]
        public void Update()
        {
            InitializeDataBase();

            Address address = new Address()
            {
                Id = 3,
                Street = "Rua 10 Alterada",
                CEP = "123456789",
                Number = 185,
                Neighborhood = "Teste 3",
                Complement = "Teste 3",
                City = new() { Id = 10, Description = "City 10 alterada" }
            };

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAddressServiceContext(options))
            {
                AddressesController addressController = new AddressesController(context, null);
                Address ad = addressController.PutAddress(3, address).Result.Value;
                Assert.Null(ad);
            }
        }

        [Fact]
        public void Delete()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new AndreTurismoAppAddressServiceContext(options))
            {
                AddressesController addressController = new AddressesController(context, null);
                Address address = addressController.DeleteAddress(2).Result.Value;
                Assert.Null(address);
            }
        }

    }
}
