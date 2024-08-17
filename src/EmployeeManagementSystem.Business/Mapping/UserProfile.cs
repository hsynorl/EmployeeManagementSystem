using AutoMapper;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Enums;
using EmployeeManagementSystem.Common.ViewModel;
using EmployeeManagementSystem.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Business.Mapping
{
    public class UserProfile:Profile
    {
        public UserProfile() {
            CreateMap<User, UserViewModel>()
                .ForMember(p=>p.UserId,y=>y.MapFrom(z=>z.Id))
                .ReverseMap();
            CreateMap<CreateUserCommand,User >()
                .ForMember(p=>p.UserType,y=>y.MapFrom(z=>UserType.User))
                .ReverseMap();
            CreateMap<User, UpdateUserCommand>()
                .ForMember(p => p.UserId, y => y.MapFrom(z => z.Id))
                .ReverseMap();
        }
    }

}
