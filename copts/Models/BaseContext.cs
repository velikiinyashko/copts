using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace copts.Models
{
    public class BaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TaskObj> Tasks { get; set; }
        public DbSet<PriorityTask> Prioritys { get; set; }
        public DbSet<StatusTask> Statuss { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=db.copts.ru;Port=1111;Database=copts;Username=root;Password=0nA7yW19");
        //}

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
    }
}
