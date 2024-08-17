using EmployeeManagementSystem.Client.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;

namespace EmployeeManagementSystem.Client.Controllers
{
    public class UserDepartmentController : Controller
    {
        private readonly ILogger<UserDepartmentController> _logger;
        private readonly IUserService userService;
        private readonly IDepartmentService departmentService;
        private readonly IUserDepartmentService userDepartmentService;
        public UserDepartmentController(ILogger<UserDepartmentController> logger, IDepartmentService departmentService, IUserService userService, IUserDepartmentService userDepartmentService)
        {
            _logger = logger;
            this.departmentService = departmentService;
            this.userService = userService;
            this.userDepartmentService = userDepartmentService;
        }
        public async Task<IActionResult> NewUserDepartment()
        {
            var users = await userService.GetUsers();
            var departments = await departmentService.GetDepartments();
            if (!users.Success || !departments.Success)
            {
                return View(null);

            }
            ViewBag.Users = users.Result
                .Select(u => new SelectListItem
                {
                    Value = u.UserId.ToString(),
                    Text = u.FirstName 
                })
                .ToList();

            ViewBag.Departments = departments.Result
                .Select(d => new SelectListItem
                {
                    Value = d.DepartmentId.ToString(),
                    Text = d.Name
                })
                .ToList();

            return View();
        }

        public async Task<ActionResult> CreateUserDepartment(CreateUserDepartmentCommand createUserDepartmentCommand)
        {
            var result = await userDepartmentService.CreateUserDepartment(createUserDepartmentCommand);
            if (result != null)
            {
                return RedirectToAction("NewUserDepartment", "UserDepartment");

            }
            return RedirectToAction("GetDepartments", "Department");

        }
    }
}