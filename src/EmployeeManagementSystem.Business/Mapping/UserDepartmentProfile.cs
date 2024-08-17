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
          

            CreateMap<UserDepartment, UpdateUserDepartmentCommand>()
                .ForMember(p => p.UserId, y => y.MapFrom(z => z.Id))
                .ReverseMap();
        }
    }

}
