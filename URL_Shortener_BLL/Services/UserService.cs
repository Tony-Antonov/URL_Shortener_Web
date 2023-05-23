using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_BLL.Interfaces;
using URL_Shortener_BLL.Models;
using URL_Shortener_DAL.Entities;
using URL_Shortener_DAL.Interfaces;

namespace URL_Shortener_BLL.Services
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork DataBase;
        private readonly SignInManager<UserEntity> signInManager;
        UserManager<UserEntity> userManager;
        RoleManager<IdentityRole<int>> roleManager;


        public UserService(IUnitOfWork dataBase, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            DataBase = dataBase;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public async Task<UserEntity> GetByUserName(string userName)
        {
            return await DataBase.Users.GetByUserName(userName);
        }

        public async Task Register(User user)
        {
            try
            {
                var result = await userManager.CreateAsync(UserToDALUser(user), user.Password);

                var UserRoles = from r in roleManager.Roles.ToList()
                                where r.Name == "admin"
                                select r.Name;

                var result2 = await userManager.AddToRolesAsync(UserToDALUser(user), UserRoles);

                if (result.Succeeded && result2.Succeeded)
                {

                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch
            {

            }
        }

        public async Task Login(string UserName, string Password)//Заменить на класс LoginData
        {
            var result = await signInManager.PasswordSignInAsync(UserName, Password, false ,false); //поменять false false на RememberMe & LockOutOnFailre

            if (result.Succeeded)
            {
                var user = await DataBase.Users.GetByUserName(UserName);
                var a = await userManager.IsInRoleAsync(user, "admin");
                var h = 5;
            }
            else
            {
                //ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }
        }



        private UserEntity UserToDALUser(User user)
        {
            return new UserEntity()
            {
                UserName = user.Username,
            };
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
