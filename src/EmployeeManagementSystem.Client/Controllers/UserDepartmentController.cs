using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Client.Controllers
{
    public class UserDepartmentController : Controller
    {
        private readonly ILogger<UserDepartmentController> _logger;

        public UserDepartmentController(ILogger<UserDepartmentController> logger)
        {
            _logger = logger;
        }

    }
}