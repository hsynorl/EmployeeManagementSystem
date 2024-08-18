using EmployeeManagementSystem.Client.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Query;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;

namespace EmployeeManagementSystem.Client.Services.Concrete
{
    public class UserDepartmentService : IUserDepartmentService
    {
        private readonly HttpClient httpClient;

        public UserDepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Common.Results.IResult> CreateUserDepartment(CreateUserDepartmentCommand createUserDepartmentCommand)
        {
            var response = await httpClient.PostAsJsonAsync("userdepartments/create-userdepartment", createUserDepartmentCommand);

            if (response.IsSuccessStatusCode)
            {
                var createUserDepartmentResponse = await response.Content.ReadFromJsonAsync<Common.Results.Result>();

                if (createUserDepartmentResponse.Success)
                {
                    return createUserDepartmentResponse;
                }
            }
            return null;
        }

        public async Task<Common.Results.IResult> DeleteUserDepartment(Guid userId)
        {
            var response = await httpClient.DeleteAsync($"userdepartments/delete-userdepartment?userId={userId}");

            if (response.IsSuccessStatusCode)
            {
                var deleteResponse = await response.Content.ReadFromJsonAsync<Common.Results.Result>();

                if (deleteResponse.Success)
                {
                    return deleteResponse;
                }
            }
            return null;
        }

        public async Task<IDataResult<List<UserDepartmentsViewModel>>> GetDepartmentUsers()
        {
            var response = await httpClient.GetFromJsonAsync<DataResult<List<UserDepartmentsViewModel>>>("UserDepartments/get-department-users");
            return response;
        }

        public Task<IDataResult<DepartmentViewModel>> GetUserDepartmentByUserId(GetUserDepartmentQuery getUserDepartmentQuery)
        {
            throw new NotImplementedException();
        }

        public async Task<Common.Results.IResult> UpdateUserDepartment(UpdateUserDepartmentCommand updateUserDepartmentCommand)
        {
            var response = await httpClient.PutAsJsonAsync("UserDepartments/update-userdepartment", updateUserDepartmentCommand);

            if (response.IsSuccessStatusCode)
            {
                var updateResponse = await response.Content.ReadFromJsonAsync<Common.Results.Result>();

                if (updateResponse.Success)
                {
                    return updateResponse;
                }
            }
            return null;
        }
    }
}
