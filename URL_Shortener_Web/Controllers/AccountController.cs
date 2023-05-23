using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener_BLL.Interfaces;
using URL_Shortener_BLL.Models;
using URL_Shortener_BLL.Services;
using URL_Shortener_DAL.Entities; //УБРАТЬ ПЕРЕНСТИ В БИЗНЕС ЛОГИКУ
using URL_Shortener_Web.Models;

namespace URL_Shortener_Web.Controllers
{
    public class AccountController : Controller
    {
        const string member = "member"; //Вынести
        const string admin = "admin";

        IUserService userService;

        public AccountController(IUserService userService) 
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel)
        {
            await userService.Register(ToDomainModel(regModel));
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                await userService.Login(loginModel.Username, loginModel.Password);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Wrong login or (and) password");
            }
            return View(loginModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();
            return RedirectToAction("Index", "Home");
        }

        private User ToDomainModel(RegisterViewModel regModel)
        {
            return new User()
            {
                Username = regModel.UserName,
                Password = regModel.Password,
            };
        } 
    }
}
