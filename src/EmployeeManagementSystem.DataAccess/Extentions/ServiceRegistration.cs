using EmployeeManagementSystem.DataAccess.Context;
using EmployeeManagementSystem.DataAccess.Repositories.Abstract;
using EmployeeManagementSystem.DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.DataAccess.Extentions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDataAccessService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<EmployeeManagementSystemDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlServer"));

            });
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDepartmentRepository, UserDepartmentRepository>();
            

            return services;

        }
    }
}
