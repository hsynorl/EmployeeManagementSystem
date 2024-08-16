using EmployeeManagementSystem.Business.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
       private readonly IDepartmentService departmentsService;

        public DepartmentsController(IDepartmentService departmentsService)
        {
            this.departmentsService = departmentsService;
        }


        [HttpGet("get-departments")]
        public async Task<IActionResult> GetDepartments()
        {
            var result=await departmentsService.GetDepartments();
            return Ok(result);
        }
        [HttpGet("get-departments-by-user-id")]
        public async Task<IActionResult> GetUserDepartmentByUserId([FromQuery]Guid userId)
        {
            var result = await departmentsService.GetUserDepartmentByUserId(new()
            {
                UserId=userId   
            });
            return Ok(result);
        }
        [HttpPost("create-department")]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand)
        {
            var result=await departmentsService.CreateDepartment(createDepartmentCommand);
            return Ok(result);
        }
        [HttpPut("update-department")]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentCommand updateDepartmentCommand)
        {
            var result = await departmentsService.UpdateDepartment(updateDepartmentCommand);
            return Ok(result);
        }

        [HttpDelete("delete-department")]
        public async Task<IActionResult> DeleteDepartment([FromQuery]Guid departmentId )
        {
            var result = await departmentsService.DeleteDepartment(new()
            {
                DepartmentId=departmentId   
            });
            return Ok(result);
        }
    }
}
