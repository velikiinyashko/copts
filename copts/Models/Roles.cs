using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace copts.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Users> Users { get; set; }

        public Roles()
        {
            Users = new List<Models.Users>();
        }
    }
}
