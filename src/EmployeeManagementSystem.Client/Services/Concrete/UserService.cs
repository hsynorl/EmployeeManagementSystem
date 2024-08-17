using EmployeeManagementSystem.Client.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Results;
using EmployeeManagementSystem.Common.ViewModel;
using System.Text.Json;


namespace EmployeeManagementSystem.Client.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Common.Results.IResult> CreateUser(CreateUserCommand createUserCommand)
        {
            var response = await httpClient.PostAsJsonAsync("users/create-user", createUserCommand);

            if (response.IsSuccessStatusCode)
            {
                var createUserResponse = await response.Content.ReadFromJsonAsync<Common.Results.Result>();

                if (createUserResponse.Success)
                {
                    return createUserResponse;
                }
            }
            return null;
        }

        public async Task<Common.Results.IResult> DeleteUser(Guid userId )
        {
            var response = await httpClient.DeleteAsync($"users/delete-user?userId={userId}");

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

        public async Task<IDataResult<List<UserViewModel>>> GetUsers()
        {
            var response = await httpClient.GetFromJsonAsync<DataResult<List<UserViewModel>>>("Users/get-users");
            return response;
            
        }

        public async Task<IDataResult<LoginViewModel>> Login(LoginCommand loginCommand)
        {
            var response = await httpClient.PostAsJsonAsync("Users/login", loginCommand);

            if (response.IsSuccessStatusCode)
            {
                var loginViewModel = await response.Content.ReadFromJsonAsync<DataResult<LoginViewModel>>();

                if (loginViewModel.Success)
                {
                    return loginViewModel;
                }
            }
            return null;
        }

        public async Task<Common.Results.IResult> UpdateUser(UpdateUserCommand updateUserCommand)
        {
            var response = await httpClient.PutAsJsonAsync("Users/update-user", updateUserCommand);

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
