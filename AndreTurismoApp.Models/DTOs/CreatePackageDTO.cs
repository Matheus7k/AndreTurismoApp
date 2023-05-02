using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models.DTOs
{
    public class CreatePackageDTO
    {
        public int HotelId { get; set; }
        public int TicketId { get; set; }
        public int CustomerId { get; set; }
        public double Price { get; set; }
    }
}
