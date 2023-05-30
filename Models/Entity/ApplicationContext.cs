using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CareService.Models.Entity
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Models.Task> Tasks => Set<Models.Task>();
        public DbSet<Models.TaskStatus> TaskStatuses => Set<Models.TaskStatus>();
        public DbSet<Models.Employee> Employees => Set<Models.Employee>();
        public DbSet<Models.Customer> Customers => Set<Models.Customer>();
        public DbSet<Models.Role> Roles => Set<Models.Role>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }
}
