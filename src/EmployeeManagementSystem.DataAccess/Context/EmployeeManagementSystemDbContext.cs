using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Entities.Entities;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagementSystem.DataAccess.Context
{
    public class EmployeeManagementSystemDbContext : DbContext
    {
        IConfiguration configuration;
        public EmployeeManagementSystemDbContext()
        {
            Database.Migrate();
        }
        public EmployeeManagementSystemDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<UserDepartment> UserDepartments{ get; set; }
        public DbSet<User> Users { get; set; }
   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = configuration.GetConnectionString("sqlServer");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserDepartment)
                .WithOne(du => du.User)
                .HasForeignKey<UserDepartment>(du => du.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}