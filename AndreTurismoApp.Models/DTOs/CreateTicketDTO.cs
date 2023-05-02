using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models.DTOs
{
    public class CreateTicketDTO
    {
        public CreateAddressDTO Origin { get; set; }
        public CreateAddressDTO Destination { get; set; }
        public int CustomerId { get; set; }
        public double Price { get; set; }
    }
}
