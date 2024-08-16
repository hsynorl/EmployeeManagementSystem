using EmployeeManagementSystem.Business.Services.Abstract;
using EmployeeManagementSystem.Business.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Extentions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {

            var assm = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assm);


            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IUserDepartmentService, UserDepartmentService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
