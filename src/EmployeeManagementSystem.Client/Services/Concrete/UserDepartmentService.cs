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

        public Task<Common.Results.IResult> DeleteUserDepartment(DeleteUserDepartmentCommand deleteUserDepartmentCommand)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<UserViewModel>>> GetDepartmentUsers(GetDepartmentUsersQuery getDepartmentUsersQuery)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DepartmentViewModel>> GetUserDepartmentByUserId(GetUserDepartmentQuery getUserDepartmentQuery)
        {
            throw new NotImplementedException();
        }

        public Task<Common.Results.IResult> UpdateUserDepartment(UpdateUserDepartmentCommand updateUserDepartmentCommand)
        {
            throw new NotImplementedException();
        }
    }
}
