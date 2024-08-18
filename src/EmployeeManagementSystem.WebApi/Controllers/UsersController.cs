using EmployeeManagementSystem.Business.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(UserType.Admin))]

    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            var result = await userService.CreateUser(createUserCommand);
            return Ok(result);

        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            var result = await userService.Login(loginCommand);
            return Ok(result);

        }
        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand updateUserCommand)
        {
            var result = await userService.UpdateUser(updateUserCommand);
            return Ok(result);

        }
        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser([FromQuery]Guid userId)
        {
            var result = await userService.DeleteUser(new()
            {
                UserId=userId   
            });
            return Ok(result);

        }

        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsers()
        {
            var result=await userService.GetUsers();        
            return Ok(result);  
        }
        [HttpGet("get-users-without-department")]
        public async Task<IActionResult> GetUsersWithOutDepartment()
        {
            var result = await userService.GetUsersWithOutDepartment();
            return Ok(result);
        }
    }
}
