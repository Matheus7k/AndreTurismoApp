using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.CustomerService.Data
{
    public class AndreTurismoAppCustomerServiceContext : DbContext
    {
        public AndreTurismoAppCustomerServiceContext (DbContextOptions<AndreTurismoAppCustomerServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.Customer> Customer { get; set; } = default!;
    }
}
