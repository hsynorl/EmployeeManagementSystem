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

        public async Task<Common.Results.IResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand)
        {
            var response = await httpClient.PostAsJsonAsync("departments/create-department", createDepartmentCommand);

            if (response.IsSuccessStatusCode)
            {
                var createDepartmentResponse = await response.Content.ReadFromJsonAsync<Common.Results.Result>();

                if (createDepartmentResponse.Success)
                {
                    return createDepartmentResponse;
                }
            }
            return null;
        }

        public async Task<Common.Results.IResult> DeleteDepartment(Guid departmentId)
        {
            var response = await httpClient.DeleteAsync($"departments/delete-department?departmentId={departmentId}");

            if (response.IsSuccessStatusCode)
            {
                var deleteDepartmentResponse = await response.Content.ReadFromJsonAsync<Common.Results.Result>();

                if (deleteDepartmentResponse.Success)
                {
                    return deleteDepartmentResponse;
                }
            }
            return null;
        }

        public async Task<IDataResult<List<DepartmentViewModel>>> GetDepartments()
        {
            var response = await httpClient.GetFromJsonAsync<DataResult<List<DepartmentViewModel>>>("Departments/get-departments");
            return response;
        }

        public async Task<Common.Results.IResult> UpdateDepartment(UpdateDepartmentCommand updateDepartmentCommand)
        {
            var response = await httpClient.PutAsJsonAsync("departments/update-department", updateDepartmentCommand);

            if (response.IsSuccessStatusCode)
            {
                var updateDepartmentResponse = await response.Content.ReadFromJsonAsync<Common.Results.Result>();

                if (updateDepartmentResponse.Success)
                {
                    return updateDepartmentResponse;
                }
            }
            return null;
        }
    }
}
