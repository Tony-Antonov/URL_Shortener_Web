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
    public class UserRepository : IRepository<UserEntity>
    {
        private readonly IUrlShortenerContext db;
        public UserRepository(IUrlShortenerContext context)
        {
            db = context;
        }
        public Task<Result> Create(UserEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<UserEntity>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(UserEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
