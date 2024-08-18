using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Query;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;

namespace EmployeeManagementSystem.Business.Services.Abstract
{
    public interface IUserDepartmentService
    {
        Task<IResult> CreateUserDepartment(CreateUserDepartmentCommand createUserDepartmentCommand);
        Task<IResult> UpdateUserDepartment(UpdateUserDepartmentCommand updateUserDepartmentCommand);
        Task<IResult> DeleteUserDepartment(DeleteUserDepartmentCommand deleteUserDepartmentCommand);
        Task<IDataResult<List<UserDepartmentsViewModel>>> GetDepartmentUsers();
        Task<IDataResult<DepartmentViewModel>> GetUserDepartmentByUserId(GetUserDepartmentQuery getUserDepartmentQuery);

    }
}
