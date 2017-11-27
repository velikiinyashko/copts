using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace copts.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public int? RulesId { get; set; }
        public Rules Rules { get; set; }

        public int? CompanyId { get; set; }
        public Companys Company { get; set; }
    }
}
