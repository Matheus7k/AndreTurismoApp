using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.AddressService.Data;
using AndreTurismoApp.CustomerService.Controllers;
using AndreTurismoApp.CustomerService.Data;
using AndreTurismoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AndreTurismoApp.Teste
{
    public class UnitTestCustomer
    {
        private DbContextOptions<AndreTurismoAppCustomerServiceContext> options;

        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismoAppCustomerServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismoAppCustomerServiceContext(options))
            {
                context.Customer.Add(new Customer { Name = "Teste 1", Phone = "16996363004", Address = new Address { Id = 1, Street = "Street 1", CEP = "123456789", Number = 183, Neighborhood = "Teste 1", Complement = "Teste 1", City = new City() { Id = 1, Description = "City1" } } });
                context.Customer.Add(new Customer { Name = "Teste 2", Phone = "16996363004", Address = new Address { Id = 2, Street = "Street 2", CEP = "123456789", Number = 184, Neighborhood = "Teste 2", Complement = "Teste 2", City = new City() { Id = 2, Description = "City2" } } });
                context.Customer.Add(new Customer { Name = "Teste 3", Phone = "16996363004", Address = new Address { Id = 3, Street = "Street 3", CEP = "123456789", Number = 185, Neighborhood = "Teste 3", Complement = "Teste 3", City = new City() { Id = 3, Description = "City3" } } });
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppCustomerServiceContext(options))
            {
                CustomersController customerClient = new(context);
                IEnumerable<Customer> customers = customerClient.GetCustomer().Result.Value;

                Assert.Equal(3, customers.Count());
            }
        }

        [Fact]
        public void GetById()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppCustomerServiceContext(options))
            {
                CustomersController customerClient = new(context);
                Customer customer = customerClient.GetCustomer(2).Result.Value;
                Assert.Equal(2, customer.Id);
            }
        }

        [Fact]
        public void Create()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppCustomerServiceContext(options))
            {
                Customer customer = new()
                {
                    Name = "Teste 1",
                    Phone = "16996363004",
                    Address = new Address
                    {
                        Street = "Street 1",
                        CEP = "123456789",
                        Number = 183,
                        Neighborhood = "Teste 1",
                        Complement = "Teste 1",
                        City = new City()
                        {
                            Description = "City1"
                        }
                    }
                };

                CustomersController customerClient = new(context);
                Customer customerReponse = customerClient.PostCustomer(customer).Result.Value;
                Assert.Equal("16996363004", customerReponse.Phone);
            }
        }

        [Fact]
        public void Update()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppCustomerServiceContext(options))
            {
                Customer customer = new()
                {
                    Id = 2,
                    Name = "Teste 1",
                    Phone = "16996363004",
                    Address = new Address
                    {
                        Id = 2,
                        Street = "Street 2",
                        CEP = "123456789",
                        Number = 183,
                        Neighborhood = "Teste 2",
                        Complement = "Teste 2",
                        City = new City()
                        {
                            Id = 2,
                            Description = "City2"
                        }
                    }
                };

                CustomersController customerClient = new(context);
                Customer customerResponse = customerClient.PutCustomer(2, customer).Result.Value;
                Assert.Null(customerResponse);
            }
        }

        [Fact]
        public void Delete()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppCustomerServiceContext(options))
            {
                CustomersController customerClient = new(context);
                Customer customerResponse = customerClient.DeleteCustomer(3).Result.Value;                
                Assert.Null(customerResponse);
            }
        }
    }
}
