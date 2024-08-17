using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;

namespace EmployeeManagementSystem.Client.Services.Abstract
{
    public interface IUserService
    {
        Task<Common.Results.IResult> CreateUser(CreateUserCommand createUserCommand);
        Task<IDataResult<LoginViewModel>> Login(LoginCommand loginCommand);
        Task<Common.Results.IResult> UpdateUser(UpdateUserCommand updateUserCommand);
        Task<Common.Results.IResult> DeleteUser(Guid userId);
        Task<IDataResult<List<UserViewModel>>> GetUsers();
    }
}
