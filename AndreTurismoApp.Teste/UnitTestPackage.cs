using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;
using AndreTurismoApp.PackageService.Controllers;
using AndreTurismoApp.PackageService.Data;
using AndreTurismoApp.TicketService.Data;
using Microsoft.EntityFrameworkCore;

namespace AndreTurismoApp.Teste
{
    public class UnitTestPackage
    {
        private DbContextOptions<AndreTurismoAppPackageServiceContext> options;

        private void InitializeDataBase()
        {
            // Create a Temporary Database
            options = new DbContextOptionsBuilder<AndreTurismoAppPackageServiceContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert data into the database using one instance of the context
            using (var context = new AndreTurismoAppPackageServiceContext(options))
            {
                
                context.Package.Add(new Package
                {
                    Price = 1001,
                    Hotel = new Hotel
                    {
                        Name = "Teste 1",
                        Price = 1001,
                        Address = new Address
                        {
                            Street = "Street 1",
                            CEP = "123456789",
                            Number = 181,
                            Neighborhood = "Teste 1",
                            Complement = "Teste 1",
                            City = new City()
                            {
                                Description = "City1"
                            }
                        }
                    },
                    Ticket = new Ticket
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
                    },
                    Customer = new Customer
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
                    }
                });
                context.Package.Add(new Package
                {
                    Price = 1001,
                    Hotel = new Hotel
                    {
                        Name = "Teste 1",
                        Price = 1001,
                        Address = new Address
                        {
                            Street = "Street 1",
                            CEP = "123456789",
                            Number = 181,
                            Neighborhood = "Teste 1",
                            Complement = "Teste 1",
                            City = new City()
                            {
                                Description = "City1"
                            }
                        }
                    },
                    Ticket = new Ticket
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
                    },
                    Customer = new Customer
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
                    }
                });
                context.Package.Add(new Package
                {
                    Price = 1001,
                    Hotel = new Hotel
                    {
                        Name = "Teste 1",
                        Price = 1001,
                        Address = new Address
                        {
                            Street = "Street 1",
                            CEP = "123456789",
                            Number = 181,
                            Neighborhood = "Teste 1",
                            Complement = "Teste 1",
                            City = new City()
                            {
                                Description = "City1"
                            }
                        }
                    },
                    Ticket = new Ticket
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
                    },
                    Customer = new Customer
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
                    }
                });                

                context.SaveChanges();
            }
        }

        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppPackageServiceContext(options))
            {
                PackagesController packageController = new(context);
                IEnumerable<Package> packages = packageController.GetPackage().Result.Value;
                Assert.Equal(3, packages.Count());
            }
        }
                
        [Fact]
        public void GetById()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppPackageServiceContext(options))
            {
                PackagesController packageController = new(context);
                Package package = packageController.GetPackage(2).Result.Value;
                Assert.Equal(2, package.Id);
            }
        }

        [Fact]
        public void Create()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppPackageServiceContext(options))
            {
                Package package = new()
                {
                    Price = 1001,
                    Hotel = new Hotel
                    {
                        Name = "Teste 1",
                        Price = 1001,
                        Address = new Address
                        {
                            Street = "Street 1",
                            CEP = "123456789",
                            Number = 181,
                            Neighborhood = "Teste 1",
                            Complement = "Teste 1",
                            City = new City()
                            {
                                Description = "City1"
                            }
                        }
                    },
                    Ticket = new Ticket
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
                    },
                    Customer = new Customer
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
                    }
                };

                PackagesController packageController = new(context);
                Package packageResponse = packageController.PostPackage(package).Result.Value;
                Assert.Equal(4, packageResponse.Id);
            }
        }

        [Fact]
        public void Update()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppPackageServiceContext(options))
            {
                Package package = new()
                {
                    Id = 2,
                    Price = 777,
                    Hotel = new Hotel
                    {
                        Name = "Teste 1",
                        Price = 1001,
                        Address = new Address
                        {
                            Street = "Street 1",
                            CEP = "123456789",
                            Number = 181,
                            Neighborhood = "Teste 1",
                            Complement = "Teste 1",
                            City = new City()
                            {
                                Description = "City1"
                            }
                        }
                    },
                    Ticket = new Ticket
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
                    },
                    Customer = new Customer
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
                    }
                };

                PackagesController packageController = new(context);
                Package packageResponse = packageController.PutPackage(2, package).Result.Value;
                Assert.Equal(777, package.Price);
            }
        }

        [Fact]
        public void Delete()
        {
            InitializeDataBase();

            using (var context = new AndreTurismoAppPackageServiceContext(options))
            {
                PackagesController packageController = new(context);
                Package package = packageController.DeletePackage(2).Result.Value;
                Assert.Null(package);
            }
        }        
    }
}
