using URL_Shortener_BLL.Models;
using URL_Shortener_Common.Models;
using URL_Shortener_DAL.Entities;

namespace URL_Shortener_BLL.Interfaces
{
    public interface IUserService
    {
        public Task<UserEntity> GetByUserName(string userName);

        public Task<Result> Register(User user);

        public Task<Result> Login(string UserName, string Password);

        public Task Logout();
    }
}
