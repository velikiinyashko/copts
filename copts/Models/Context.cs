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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=db.copts.ru;Port=1111;Database=copts;Username=root;Password=0nA7yW19");
        //}

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
