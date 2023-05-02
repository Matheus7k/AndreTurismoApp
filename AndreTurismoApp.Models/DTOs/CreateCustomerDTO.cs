using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models.DTOs
{
    public class CreateCustomerDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CEP { get; set; }
        public int Number { get; set; }
    }
}
