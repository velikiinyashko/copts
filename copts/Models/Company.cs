using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace copts.Models
{
    public class Company
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

        public List<User> Users { get; set; }

        public Company()
        {
            Users = new List<Models.User>();
        }
    }
}
