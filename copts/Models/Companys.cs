using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace copts.Models
{
    public class Companys
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Post { get; set; }
        public string Country { get; set; }
        public string Sity { get; set; }
        public string Address { get; set; }
        public string Bank { get; set; }
        public int Inn { get; set; }
        public int Kpp { get; set; }

        public List<Users> Users { get; set; }

        public Companys()
        {
            Users = new List<Models.Users>();
        }
    }
}
