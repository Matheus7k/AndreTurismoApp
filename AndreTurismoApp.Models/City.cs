using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class City
    {
        public static string INSERT = "insert into City (Description, DateCreated) values (@Description, @DateCreated); select cast(scope_identity() as int)";
        public static string GETBYID = "select Id, Description, DateCreated from City where Id = @Id";
        public static string GETALL = "select Id, Description, DateCreated from City";

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
