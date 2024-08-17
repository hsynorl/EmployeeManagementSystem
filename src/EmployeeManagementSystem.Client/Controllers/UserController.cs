using EmployeeManagementSystem.Client.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Client.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        public async Task<ActionResult> Users()
        {
            var result =await userService.GetUsers();
            if (result!=null)
            {
            return View(result.Result);  

            }
            return RedirectToAction("Index", "Home");

        }

    }
}