using AutoMapper;
using EmployeeManagementSystem.Business.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Query;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;
using EmployeeManagementSystem.DataAccess.Repositories.Abstract;
using EmployeeManagementSystem.DataAccess.Repositories.Concrete;
using EmployeeManagementSystem.Entities.Entities;

namespace EmployeeManagementSystem.Business.Services.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }

        public async Task<IResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand)
        {
            var department = mapper.Map<Department>(createDepartmentCommand);
            var result = await departmentRepository.AddAsync(department);
            if (result > 0)
            {
                return new SuccessResult("Department eklendi");
            }
            return new ErrorResult("Department eklenemedi");
        }

        public async Task<IResult> DeleteDepartment(DeleteDepartmentCommand deleteDepartmentCommand)
        {
            var department = await departmentRepository.GetSingleAsync(p => p.Id == deleteDepartmentCommand.DepartmentId);
            if (department == null)
            {
                return new ErrorResult("Department bulunamadı");
            }
            var result = await departmentRepository.DeleteAsync(department);
            if (result > 0)
            {

                return new SuccessResult("Department silindi");
            }
            return new ErrorResult("Department silinemedi");
        }

        public async Task<IDataResult<List<DepartmentViewModel>>> GetDepartments()
        {
            var result = await departmentRepository.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<DepartmentViewModel>>("Department bulunamadı");
            }
            var departments = mapper.Map<List<DepartmentViewModel>>(result);
            return new SuccessDataResult<List<DepartmentViewModel>>(departments);
        }

        public async Task<IDataResult<DepartmentViewModel>> GetUserDepartmentByUserId(GetUserDepartmentQuery getUserDepartmentQuery)
        {
           var result=await departmentRepository.GetList(p=>p.Id==getUserDepartmentQuery.UserId);
            if (result == null)
            {
                return new ErrorDataResult<DepartmentViewModel>("Department bulunamadı");
            }
            var department=mapper.Map<DepartmentViewModel>(result);
           
            return new SuccessDataResult<DepartmentViewModel>(department);
        }

        public async Task<IResult> UpdateDepartment(UpdateDepartmentCommand updateDepartmentCommand)
        {
            var department = await departmentRepository.GetSingleAsync(p => p.Id == updateDepartmentCommand.DepartmentId);
            if (department == null)
            {
                return new ErrorResult("Department bulunamadı");
            }
            mapper.Map(updateDepartmentCommand, department);
            var result = await departmentRepository.UpdateAsync(department);
            if (result > 0)
            {
                return new SuccessResult("Department güncellendi");
            }
            return new ErrorResult("Department güncellenemedi");
        }
    }
}
