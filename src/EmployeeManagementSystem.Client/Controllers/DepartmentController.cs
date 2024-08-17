using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Client.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _logger = logger;
        }

    }
}