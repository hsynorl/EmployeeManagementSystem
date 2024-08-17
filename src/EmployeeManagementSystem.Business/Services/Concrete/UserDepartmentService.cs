using AutoMapper;
using EmployeeManagementSystem.Business.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Query;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;
using EmployeeManagementSystem.DataAccess.Repositories.Abstract;
using EmployeeManagementSystem.DataAccess.Repositories.Concrete;
using EmployeeManagementSystem.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Business.Services.Concrete
{
    public class UserDepartmentService : IUserDepartmentService
    {
        private readonly IUserDepartmentRepository userDepartmentRepository;
        private readonly IMapper mapper;
        public UserDepartmentService(IUserDepartmentRepository userDepartmentRepository, IMapper mapper)
        {
            this.userDepartmentRepository = userDepartmentRepository;
            this.mapper = mapper;
        }

        public async Task<IResult> CreateUserDepartment(CreateUserDepartmentCommand createUserDepartmentCommand)
        {
            var userDepartment = mapper.Map<UserDepartment>(createUserDepartmentCommand);
            userDepartment.User = null;
            var result = await userDepartmentRepository.AddAsync(userDepartment);
            if (result > 0)
            {
                return new SuccessResult("Kullanıcı department'a eklendi");
            }
            return new ErrorResult("Kullanıcı department'a eklenemedi");
        }

        public async Task<IResult> DeleteUserDepartment(DeleteUserDepartmentCommand deleteUserDepartmentCommand)
        {
            var user = await userDepartmentRepository.GetSingleAsync(p => p.Id == deleteUserDepartmentCommand.UserId);
            if (user == null)
            {
                return new ErrorResult("Kullanıcı department'da bulunamadı");
            }
            var result = await userDepartmentRepository.DeleteAsync(user);
            if (result > 0)
            {

                return new SuccessResult("Kullanıcı silindi");
            }
            return new ErrorResult("Kullanıcı silinemedi");
        }

        public async Task<IDataResult<DepartmentViewModel>> GetUserDepartmentByUserId(GetUserDepartmentQuery getUserDepartmentQuery)
        {
            var result = await userDepartmentRepository.AsQueryable().Include(p=>p.Department).FirstOrDefaultAsync(p => p.Id == getUserDepartmentQuery.UserId);
            if (result == null)
            {
                return new ErrorDataResult<DepartmentViewModel>("Department bulunamadı");
            }
            var department = mapper.Map<DepartmentViewModel>(result.Department);

            return new SuccessDataResult<DepartmentViewModel>(department);
        }

        public async Task<IDataResult<List<UserViewModel>>> GetDepartmentUsers(GetDepartmentUsersQuery getDepartmentUsersQuery)
        {
            var result = await userDepartmentRepository.AsQueryable()
                .Include(p => p.User)
                .Where(_ => true)
                .AsNoTracking()
                .ToListAsync();
            if (result.Count < 1)
            {
                return new ErrorDataResult<List<UserViewModel>>("User bulunamadı");
            }
            var users = mapper.Map<List<UserViewModel>>(result.Select(p=>p.User));
            return new SuccessDataResult<List<UserViewModel>>(users);
        }

        public async Task<IResult> UpdateUserDepartment(UpdateUserDepartmentCommand updateUserDepartmentCommand)
        {
            var userDepartment = await userDepartmentRepository.GetSingleAsync(p => p.Id == updateUserDepartmentCommand.UserId);
            if (userDepartment == null)
            {
                return new ErrorResult("User Department bulunamadı");
            }
            mapper.Map(updateUserDepartmentCommand, userDepartment);
            var result = await userDepartmentRepository.UpdateAsync(userDepartment);
            if (result > 0)
            {
                return new SuccessResult("User Department güncellendi");
            }
            return new ErrorResult("User Department güncellenemedi");
        }
    }
}
