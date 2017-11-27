using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace copts.Models
{
    public class Rules
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Users> Users { get; set; }

        public Rules()
        {
            Users = new List<Models.Users>();
        }
    }
}
