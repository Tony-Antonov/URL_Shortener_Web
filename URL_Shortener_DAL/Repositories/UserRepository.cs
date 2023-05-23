using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_Common.Models;
using URL_Shortener_DAL.Entities;
using URL_Shortener_DAL.Interfaces;

namespace URL_Shortener_DAL.Repositories
{
    internal class UserRepository : IRepository<UserEntity>
    {
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

        public Task<IQueryable<UserEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(UserEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
