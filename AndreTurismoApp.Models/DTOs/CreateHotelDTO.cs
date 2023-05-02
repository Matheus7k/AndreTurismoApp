using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models.DTOs
{
    public class CreateHotelDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public CreateAddressDTO address { get; set; }
    }
}
