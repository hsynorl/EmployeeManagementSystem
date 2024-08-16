using AutoMapper;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.ViewModel;
using EmployeeManagementSystem.Entities.Entities;

namespace EmployeeManagementSystem.Business.Mapping
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
            CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
            CreateMap<Department, UpdateDepartmentCommand>()
                .ForMember(p=>p.DepartmentId,y=>y.MapFrom(z=>z.Id))
                .ReverseMap();
            
        }
    }

}
