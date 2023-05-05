using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.DBController.Data
{
    public class AndreTurismoAppDBControllerContext : DbContext
    {
        public AndreTurismoAppDBControllerContext (DbContextOptions<AndreTurismoAppDBControllerContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.Customer> Customer { get; set; } = default!;
    }
}
