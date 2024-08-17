using EmployeeManagementSystem.Client.Services.Abstract;
using EmployeeManagementSystem.Common.Command;
using EmployeeManagementSystem.Common.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            return View(null);

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
        public async Task<ActionResult> Login()
        {
            return View();

        }
        public async Task<ActionResult> DeleteUser(Guid userId)
        {
            var result=await userService.DeleteUser(userId);
            if (result != null)
            {
                return RedirectToAction("GetUsers", "User");

            }
            return RedirectToAction("GetUsers", "User");

        }
        public async Task<IActionResult> Logout()
        {
            // Kullanıcının mevcut session'undan çıkış yap
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Kullanıcıyı başlangıç sayfasına yönlendir
            return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> Submit(LoginCommand loginCommand)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.Login(loginCommand);
                if (result is null)
                {
                    return RedirectToAction("Login");
                }
                var claims = new List<Claim>
                {
                     new Claim("Token", result.Result.Token) // Token'ı bir claim olarak ekliyoruz
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = result.Result.TokenExpire 
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);


                return RedirectToAction("GetDepartments", "Department");
            }
            return RedirectToAction("Login");
        }

    }
}