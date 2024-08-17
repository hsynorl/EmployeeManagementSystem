using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Query;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;

namespace EmployeeManagementSystem.Business.Services.Abstract
{
    public interface IDepartmentService
    {
        Task<IResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand);
        Task<IResult> UpdateDepartment(UpdateDepartmentCommand updateDepartmentCommand);
        Task<IResult> DeleteDepartment(DeleteDepartmentCommand deleteDepartmentCommand);
        Task<IDataResult<List<DepartmentViewModel>>> GetDepartments();
    }
}
