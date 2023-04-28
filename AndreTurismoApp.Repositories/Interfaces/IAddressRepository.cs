using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Address Create(Address address);
        List<Address> GetAddresses();
        Address GetAddresById(int id);
    }
}
