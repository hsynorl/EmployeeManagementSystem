using EmployeeManagementSystem.Client.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;

namespace EmployeeManagementSystem.Client.Controllers
{
    [Authorize]
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
            var users = await userService.GetUsersWithOutDepartment();
            var departments = await departmentService.GetDepartments();
            if (!users.Success || !departments.Success)
            {
                return View(null);
            }
            ViewBag.Users = users.Result
                .Select(u => new SelectListItem
                {
                    Value = u.UserId.ToString(),
                    Text = u.FirstName +" "+ u.LastName,
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
                TempData["ToastMessage"] = result.Message;
                TempData["IsError"] = false;
            }
            else
            {
                TempData["ToastMessage"] = "Departmana kullanıcı ekleme işlemi başarısız.";
                TempData["IsError"] = true;
            }
            return RedirectToAction("GetUserDepartments", "UserDepartment");
        }

        public async Task<ActionResult> GetUserDepartments()
        {
            var result = await userDepartmentService.GetDepartmentUsers();
            if (result != null)
            {
                return View(result.Result);

            }
            return View(null);

        }
        public async Task<ActionResult> UserDepartmentDetail(UserDepartmentsViewModel userDepartmentsViewModel)
        {
            var departments = await departmentService.GetDepartments();

            ViewBag.Departments = departments.Result
              .Select(d => new SelectListItem
              {
                  Value = d.DepartmentId.ToString(),
                  Text = d.Name
              })
              .ToList();
            return View(userDepartmentsViewModel);
        }
        public async Task<ActionResult> UpdateUserDepartment(UpdateUserDepartmentCommand updateUserDepartmentCommand)
        {
            var result = await userDepartmentService.UpdateUserDepartment(updateUserDepartmentCommand);
            if (result != null)
            {
                TempData["ToastMessage"] = result.Message;
                TempData["IsError"] = false;
            }
            else
            {
                TempData["ToastMessage"] = "Kullanıcı departmanı güncelleme işlemi başarısız.";
                TempData["IsError"] = true;
            }
            return RedirectToAction("GetUserDepartments", "UserDepartment");


        }
        public async Task<ActionResult> DeleteUserDepartment(Guid userId)
        {
            var result = await userDepartmentService.DeleteUserDepartment(userId);
            if (result != null)
            {
                TempData["ToastMessage"] = result.Message;
                TempData["IsError"] = false;
            }
            else
            {
                TempData["ToastMessage"] = "Kullanıcı departmanı silme işlemi başarısız.";
                TempData["IsError"] = true;
            }
            return RedirectToAction("GetUserDepartments", "UserDepartment");

        }
    }
}