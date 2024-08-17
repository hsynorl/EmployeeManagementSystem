using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Query;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;

namespace EmployeeManagementSystem.Client.Services.Abstract
{
    public interface IUserDepartmentService
    {
        Task<Common.Results.IResult> CreateUserDepartment(CreateUserDepartmentCommand createUserDepartmentCommand);
        Task<Common.Results.IResult> UpdateUserDepartment(UpdateUserDepartmentCommand updateUserDepartmentCommand);
        Task<Common.Results.IResult> DeleteUserDepartment(DeleteUserDepartmentCommand deleteUserDepartmentCommand);
        Task<IDataResult<List<UserViewModel>>> GetDepartmentUsers(GetDepartmentUsersQuery getDepartmentUsersQuery);
        Task<IDataResult<DepartmentViewModel>> GetUserDepartmentByUserId(GetUserDepartmentQuery getUserDepartmentQuery);

    }
}
