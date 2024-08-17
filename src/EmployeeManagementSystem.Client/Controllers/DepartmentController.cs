using EmployeeManagementSystem.Client.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Client.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService departmentService;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService departmentService)
        {
            _logger = logger;
            this.departmentService = departmentService;
        }
        public async Task<ActionResult> GetDepartments()
        {
            var result = await departmentService.GetDepartments();
            if (result != null)
            {
                return View(result.Result);

            }
            return View(null);

        }
        public async Task<ActionResult> DepartmentDetail(DepartmentViewModel departmentViewModel)
        {
            return View(departmentViewModel);
        }
        public async Task<ActionResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand)
        {
            var result = await departmentService.CreateDepartment(createDepartmentCommand);
            if (result != null)
            {
                return RedirectToAction("GetDepartments", "Department");

            }
            return RedirectToAction("GetDepartments", "Department");

        }


        public async Task<ActionResult> DeleteDepartment(Guid departmentId)
        {
            var result = await departmentService.DeleteDepartment(departmentId);
            if (result != null)
            {
                return RedirectToAction("GetDepartments", "Department");

            }
            return RedirectToAction("GetDepartments", "Department");

        }
        public async Task<ActionResult> UpdateDepartment(UpdateDepartmentCommand updateDepartmentCommand)
        {
            var result = await departmentService.UpdateDepartment(updateDepartmentCommand);
            if (result != null)
            {
                return RedirectToAction("GetDepartments", "Department");

            }
            return RedirectToAction("GetDepartments", "Department");

        }
        public async Task<ActionResult> NewDepartment()
        {
            return View();

        }
    }
}