using EmployeeManagementSystem.Client.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;

namespace EmployeeManagementSystem.Client.Services.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<Common.Results.IResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand)
        {
            throw new NotImplementedException();
        }

        public Task<Common.Results.IResult> DeleteDepartment(DeleteDepartmentCommand deleteDepartmentCommand)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<DepartmentViewModel>>> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<Common.Results.IResult> UpdateDepartment(UpdateDepartmentCommand updateDepartmentCommand)
        {
            throw new NotImplementedException();
        }
    }
}
