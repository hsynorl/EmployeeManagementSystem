using EmployeeManagementSystem.Business.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
