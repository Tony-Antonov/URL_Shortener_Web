using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_DAL.Context;
using URL_Shortener_DAL.Entities;
using URL_Shortener_DAL.Interfaces;

namespace URL_Shortener_DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private UrlShortenerContext db;
        private IRepository<ShortUrlEntity> shortUrlRepository;
        private IRepository<UserEntity> userRepository;


        public IRepository<UserEntity> Users 
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<ShortUrlEntity> ShortUrls
        {
            get
            {
                if (shortUrlRepository == null)
                    shortUrlRepository = new ShortUrlRepository(db);
                return shortUrlRepository;
            }
        }

        public async void Save()
        {
            await db.SaveChangesAsync();
        }

    }
}
