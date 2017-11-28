using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace copts.Models
{
    public class BaseContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Companys> Companys { get; set; }
        public DbSet<Roles> Roles { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=db.copts.ru;Port=1111;Database=copts;Username=root;Password=0nA7yW19");
        //}

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
    }
}
