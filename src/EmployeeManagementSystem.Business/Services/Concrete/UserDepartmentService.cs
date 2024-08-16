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

        public Task<IDataResult<List<UserViewModel>>> GetDepartmentUsers(GetDepartmentUsersQuery getDepartmentUsersQuery)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateUserDepartment(UpdateUserDepartmentCommand updateUserDepartmentCommand)
        {
            throw new NotImplementedException();
        }
    }
}
