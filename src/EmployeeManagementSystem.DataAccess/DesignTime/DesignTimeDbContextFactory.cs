using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem.DataAccess.Context;

namespace EmployeeManagementSystem.DataAccess.DesignTime
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EmployeeManagementSystemDbContext>
    {
        public EmployeeManagementSystemDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<EmployeeManagementSystemDbContext> dbContextOptionsBuilder = new();
            string connectionString = "Server=localhost;Database=EmployeeManagementSystemDb;User Id=sa;Password=og~8O+nwAT%5c0a8V8G]G+tEi;TrustServerCertificate=True;";

            dbContextOptionsBuilder.UseSqlServer(connectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
