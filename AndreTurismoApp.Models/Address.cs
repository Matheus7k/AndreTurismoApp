using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class Address
    {
        public static string INSERT = "insert into Address (Street, Number, Neighborhood, CEP, Complement, DateCreated, IdCity) values " +
            "(@Street, @Number, @Neighborhood, @CEP, @Complement, @DateCreated, @IdCity);  select cast(scope_identity() as int)";
        public static string GETALL = "select a.Id, a.Street, a.Number, a.Neighborhood, a.CEP, a.Complement, a.DateCreated, c.Id, c,Description from Address a join City c on a.IdCity = c.Id";        

        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string CEP { get; set; }
        public string Complement { get; set; }
        public DateTime DateCreated { get; set; }
        public City City { get; set; }
    }
}
