using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace copts.Models
{
    public class Context : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Companys> Companys { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
