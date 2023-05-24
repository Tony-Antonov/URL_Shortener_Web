using Microsoft.AspNetCore.Mvc;
using URL_Shortener_BLL.Interfaces;
using URL_Shortener_BLL.Models;
using URL_Shortener_Web.Models;

namespace URL_Shortener_Web.Controllers
{
    public class AccountController : Controller
    {
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
            if (ModelState.IsValid)
            {

                var result = await userService.Register(ToDomainModel(regModel));
                if (result.Completed)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError("", "Something Went Wrong");
                
            }
            return View(regModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.Login(loginModel.Username, loginModel.Password);
                if(result.Completed)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError("", "Wrong login or (and) password");
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
