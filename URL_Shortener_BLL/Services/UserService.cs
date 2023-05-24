using Microsoft.AspNetCore.Identity;
using URL_Shortener_BLL.Interfaces;
using URL_Shortener_BLL.Models;
using URL_Shortener_Common.Models;
using URL_Shortener_DAL.Entities;
using URL_Shortener_DAL.Interfaces;

namespace URL_Shortener_BLL.Services
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork dataBase;
        private readonly SignInManager<UserEntity> signInManager;
        private readonly UserManager<UserEntity> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public UserService(IUnitOfWork dataBase, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            dataBase = dataBase;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public async Task<UserEntity> GetByUserName(string userName)
        {
            return await dataBase.Users.GetByUserName(userName);
        }

        public async Task<Result> Register(User user)
        {

            var result = await userManager.CreateAsync(UserToDALUser(user), user.Password);

            var UserRoles = from r in roleManager.Roles.ToList()
                            where r.Name == "member"
                            select r.Name;

            var result2 = await userManager.AddToRolesAsync(await dataBase.Users.GetByUserName(user.Username), UserRoles);

            if (result.Succeeded && result2.Succeeded)
                return new Result("Authentification and authoriztion completed", true);
            else
                return new Result("Somethig went wrong", false);
        }

        public async Task<Result> Login(string UserName, string Password)//Заменить на класс LoginData
        {
            bool RememberMe = false;
            bool LockOutOnFailre = false;

            if((await signInManager.PasswordSignInAsync(UserName, Password, RememberMe, LockOutOnFailre)).Succeeded)
                return new Result("Completed", true);
            else
                return new Result("Not Completed", false);
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
