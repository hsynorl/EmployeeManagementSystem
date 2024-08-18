using EmployeeManagementSystem.Business.Services.Abstract;
using EmployeeManagementSystem.Business.Services.Concrete;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = nameof(UserType.Admin))]

    public class UserDepartmentsController : ControllerBase
    {
        private readonly IUserDepartmentService userDepartmentService;

        public UserDepartmentsController(IUserDepartmentService userDepartmentService)
        {
            this.userDepartmentService = userDepartmentService;
        }

        [HttpGet("get-department-users")]
        public async Task<IActionResult> GetDepartmentUsers()
        {
            var result = await userDepartmentService.GetDepartmentUsers();
            return Ok(result);
        }
        [HttpGet("get-departments-by-user-id")]
        public async Task<IActionResult> GetUserDepartmentByUserId([FromQuery] Guid userId)
        {
            var result = await userDepartmentService.GetUserDepartmentByUserId(new()
            {
                UserId = userId
            });
            return Ok(result);
        }
        [HttpPost("create-userdepartment")]
        public async Task<IActionResult> CreateUserDepartment(CreateUserDepartmentCommand createUserDepartmentCommand)
        {
            var result = await userDepartmentService.CreateUserDepartment(createUserDepartmentCommand);
            return Ok(result);
        }

        [HttpPut("update-userdepartment")]
        public async Task<IActionResult> UpdateUserDepartment(UpdateUserDepartmentCommand updateUserDepartmentCommand)
        {
            var result = await userDepartmentService.UpdateUserDepartment(updateUserDepartmentCommand);
            return Ok(result);
        }
        [HttpDelete("delete-userdepartment")]
        public async Task<IActionResult> DeleteUserDepartment([FromQuery]Guid userId)
        {
            var result = await userDepartmentService.DeleteUserDepartment(new()
            {
                UserId=userId   
            });
            return Ok(result);
        }
    }
}
