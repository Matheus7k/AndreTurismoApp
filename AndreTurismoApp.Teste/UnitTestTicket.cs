using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AndreTurismoApp.HotelService.Data;
using AndreTurismoApp.Models;
using AndreTurismoApp.TicketService.Controllers;
using AndreTurismoApp.TicketService.Data;
using Microsoft.EntityFrameworkCore;

namespace AndreTurismoApp.Teste
{
    public class UnitTestTicket
    {
        private DbContextOptions<AndreTurismoAppTicketServiceContext> options;

        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismoAppTicketServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismoAppTicketServiceContext(options))
            {
                context.Ticket.Add(new Ticket
                {
                    Origin = new Address
                    {
                        Street = "Origin 1",
                        CEP = "123456789",
                        Number = 181,
                        Neighborhood = "Origin 1",
                        Complement = "Origin 1",
                        City = new City()
                        {
                            Description = "Origin 1"
                        }
                    },
                    Destination = new Address
                    {
                        Street = "Destination 1",
                        CEP = "123456789",
                        Number = 181,
                        Neighborhood = "Destination 1",
                        Complement = "Destination 1",
                        City = new City()
                        {
                            Description = "Destination 1"
                        }
                    },
                    Customer = new Customer
                    {
                        Name = "Customer 1",
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
                    },
                    Price = 1001
                });
                context.Ticket.Add(new Ticket
                {
                    Origin = new Address
                    {
                        Street = "Origin 2",
                        CEP = "123456789",
                        Number = 181,
                        Neighborhood = "Origin 2",
                        Complement = "Origin 2",
                        City = new City()
                        {
                            Description = "Origin 2"
                        }
                    },
                    Destination = new Address
                    {
                        Street = "Destination 2",
                        CEP = "123456789",
                        Number = 181,
                        Neighborhood = "Destination 2",
                        Complement = "Destination 2",
                        City = new City()
                        {
                            Description = "Destination 2"
                        }
                    },
                    Customer = new Customer
                    {
                        Name = "Customer 2",
                        Phone = "16996363004",
                        Address = new Address
                        {
                            Street = "Street 2",
                            CEP = "123456789",
                            Number = 183,
                            Neighborhood = "Teste 2",
                            Complement = "Teste 2",
                            City = new City()
                            {
                                Description = "City2"
                            }
                        }
                    },
                    Price = 1002
                });
                context.Ticket.Add(new Ticket
                {
                    Origin = new Address
                    {
                        Street = "Origin 3",
                        CEP = "123456789",
                        Number = 181,
                        Neighborhood = "Origin 3",
                        Complement = "Origin 3",
                        City = new City()
                        {
                            Description = "Origin 3"
                        }
                    },
                    Destination = new Address
                    {
                        Street = "Destination 3",
                        CEP = "123456789",
                        Number = 181,
                        Neighborhood = "Destination 3",
                        Complement = "Destination 3",
                        City = new City()
                        {
                            Description = "Destination 3"
                        }
                    },
                    Customer = new Customer
                    {
                        Name = "Customer 3",
                        Phone = "16996363004",
                        Address = new Address
                        {
                            Street = "Street 3",
                            CEP = "123456789",
                            Number = 183,
                            Neighborhood = "Teste 3",
                            Complement = "Teste 3",
                            City = new City()
                            {
                                Description = "City3"
                            }
                        }
                    },
                    Price = 1003
                });
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppTicketServiceContext(options))
            {
                TicketsController ticketController = new(context);
                IEnumerable<Ticket> tickets = ticketController.GetTicket().Result.Value;
                Assert.Equal(3, tickets.Count());
            }
        }

        [Fact]
        public void GetById()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppTicketServiceContext(options))
            {
                TicketsController ticketController = new(context);
                Ticket ticket = ticketController.GetTicket(2).Result.Value;
                Assert.Equal(2, ticket.Id);
            }
        }

        [Fact]
        public void Create()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppTicketServiceContext(options))
            {
                Ticket ticket = new()
                {
                    Origin = new Address
                    {
                        Street = "Origin 4",
                        CEP = "123456789",
                        Number = 181,
                        Neighborhood = "Origin 4",
                        Complement = "Origin 4",
                        City = new City()
                        {
                            Description = "Origin 4"
                        }
                    },
                    Destination = new Address
                    {
                        Street = "Destination 1",
                        CEP = "123456789",
                        Number = 181,
                        Neighborhood = "Destination 1",
                        Complement = "Destination 1",
                        City = new City()
                        {
                            Description = "Destination 1"
                        }
                    },
                    Customer = new Customer
                    {
                        Name = "Customer 1",
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
                    },
                    Price = 1001
                };

                TicketsController ticketController = new(context);
                Ticket ticketResponse = ticketController.PostTicket(ticket).Result.Value;
                Assert.Equal("Origin 4", ticketResponse.Origin.Street);
            }
        }

        [Fact]
        public void Update()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppTicketServiceContext(options))
            {
                Ticket ticket = new()
                {
                    Id = 3,
                    Origin = new Address
                    {
                        Street = "Origin Teste",
                        CEP = "123456789",
                        Number = 181,
                        Neighborhood = "Origin Teste",
                        Complement = "Origin Teste",
                        City = new City()
                        {
                            Description = "Origin Teste"
                        }
                    },
                    Destination = new Address
                    {
                        Street = "Destination 1",
                        CEP = "123456789",
                        Number = 181,
                        Neighborhood = "Destination 1",
                        Complement = "Destination 1",
                        City = new City()
                        {
                            Description = "Destination 1"
                        }
                    },
                    Customer = new Customer
                    {
                        Name = "Customer 1",
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
                    },
                    Price = 1001
                };

                TicketsController ticketController = new(context);
                Ticket ticketResponse = ticketController.PutTicket(3, ticket).Result.Value;
                Assert.Null(ticketResponse);
            }
        }

        [Fact]
        public void Delete()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppTicketServiceContext(options))
            {
                TicketsController ticketController = new(context);
                Ticket ticket = ticketController.DeleteTicket(2).Result.Value;
                Assert.Null(ticket);
            }
        }
    }
}
