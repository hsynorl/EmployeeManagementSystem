using AutoMapper;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.ViewModel;
using EmployeeManagementSystem.Entities.Entities;

namespace EmployeeManagementSystem.Business.Mapping
{
    public class UserDepartmentProfile : Profile
    {
        public UserDepartmentProfile()
        {
            CreateMap<UserDepartment, CreateUserDepartmentCommand>()
                .ForMember(p => p.UserId, y => y.MapFrom(z => z.Id))
                .ReverseMap();
            CreateMap<UserDepartment, UserDepartmentsViewModel>()
               .ForMember(p => p.UserId, y => y.MapFrom(z => z.Id))
               .ForMember(p => p.LastName, y => y.MapFrom(z => z.User.LastName))
               .ForMember(p => p.FirstName, y => y.MapFrom(z => z.User.FirstName))
               .ForMember(p => p.DepartmentName, y => y.MapFrom(z => z.Department.Name))
               .ReverseMap();


            CreateMap<UserDepartment, UpdateUserDepartmentCommand>()
                .ForMember(p => p.UserId, y => y.MapFrom(z => z.Id))
                .ReverseMap();
        }
    }

}
