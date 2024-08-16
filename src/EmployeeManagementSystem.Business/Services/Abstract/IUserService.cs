
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;

namespace EmployeeManagementSystem.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<IResult> CreateUser(CreateUserCommand createUserCommand);
        Task<IDataResult<LoginViewModel>> Login(LoginCommand loginCommand);
        Task<IResult> UpdateUser(UpdateUserCommand updateUserCommand);
        Task<IResult> DeleteUser(DeleteUserCommand deleteUserCommand);
        Task<IDataResult<List<UserViewModel>>> GetUsers();
    }
}
