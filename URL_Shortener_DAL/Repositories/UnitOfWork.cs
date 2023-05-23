using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_DAL.Entities;
using URL_Shortener_DAL.Interfaces;

namespace URL_Shortener_DAL.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        public IRepository<UserEntity> Users => throw new NotImplementedException();

        public IRepository<ShortUrlEntity> ShortUrls => throw new NotImplementedException();

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
