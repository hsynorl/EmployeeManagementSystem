using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;

namespace EmployeeManagementSystem.Client.Services.Abstract
{
    public interface IDepartmentService
    {
        Task<Common.Results.IResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand);
        Task<Common.Results.IResult> UpdateDepartment(UpdateDepartmentCommand updateDepartmentCommand);
        Task<Common.Results.IResult> DeleteDepartment(Guid departmentId);
        Task<IDataResult<List<DepartmentViewModel>>> GetDepartments();
    }
}
