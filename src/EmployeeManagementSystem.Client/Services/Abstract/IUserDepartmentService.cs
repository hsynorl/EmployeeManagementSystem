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
        Task<Common.Results.IResult> DeleteUserDepartment(Guid userId);
        Task<IDataResult<List<UserDepartmentsViewModel>>> GetDepartmentUsers();
        Task<IDataResult<DepartmentViewModel>> GetUserDepartmentByUserId(GetUserDepartmentQuery getUserDepartmentQuery);

    }
}
