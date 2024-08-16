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
using EmployeeManagementSystem.Common.Enums;

namespace EmployeeManagementSystem.DataAccess.Context
{
    public class EmployeeManagementSystemDbContext : DbContext
    {
        public EmployeeManagementSystemDbContext(DbContextOptions<EmployeeManagementSystemDbContext> options)
          : base(options)
        {
            Database.Migrate();
        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<UserDepartment> UserDepartments{ get; set; }
        public DbSet<User> Users { get; set; }
   
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(new User()
            {
                EmailAddress = "admin@gmail.com",
                FirstName = "Hüseyin",
                LastName = "ORAL",
                Password = "admin",
                UserType = UserType.Admin,
                PhoneNumber = "05360596086",
                Id = Guid.NewGuid(),

            });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserDepartment)
                .WithOne(du => du.User)
                .HasForeignKey<UserDepartment>(du => du.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}