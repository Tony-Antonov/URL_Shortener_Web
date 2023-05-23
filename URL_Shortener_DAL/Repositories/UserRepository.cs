using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_Common.Models;
using URL_Shortener_DAL.Context;
using URL_Shortener_DAL.Entities;
using URL_Shortener_DAL.Interfaces;

namespace URL_Shortener_DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUrlShortenerContext db;

        public UserRepository(IUrlShortenerContext context) 
        {
            db = context;
        }
        
        public async Task<UserEntity> GetByUserName(string userName)
        {
            return db.users.Single(u => u.UserName == userName);
        }
    }
}
