using EmployeeManagementSystem.Client.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.ViewModel;
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

        public async Task<ActionResult> GetUsers()
        {
            var result =await userService.GetUsers();
            if (result!=null)
            {
            return View(result.Result);  

            }
            return RedirectToAction("Index", "Home");

        }
        public async Task<ActionResult> UserDetail(UserViewModel userViewModel)
        {
            return View(userViewModel);
        }

        public async Task<ActionResult> UpdateUser(UpdateUserCommand updateUserCommand)
        {
            var result = await userService.UpdateUser(updateUserCommand);
            if (result != null)
            {
                return RedirectToAction("GetUsers", "User");

            }
            return RedirectToAction("Index", "Home");

        }
        public async Task<ActionResult> CreateUser(CreateUserCommand createUserCommand)
        {
            var result = await userService.CreateUser(createUserCommand);
            if (result != null)
            {
                return RedirectToAction("GetUsers", "User");

            }
            return RedirectToAction("Index", "Home");

        }
        public async Task<ActionResult> NewUser()
        {
           return View();

        }
    }
}