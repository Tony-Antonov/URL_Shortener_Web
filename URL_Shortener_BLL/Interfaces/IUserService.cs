using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_BLL.Models;
using URL_Shortener_DAL.Entities;

namespace URL_Shortener_BLL.Interfaces
{
    public interface IUserService
    {
        public Task<UserEntity> GetByUserName(string userName);

        public Task Register(User user);

        public Task Login(string UserName, string Password);

        public Task Logout();
    }
}
