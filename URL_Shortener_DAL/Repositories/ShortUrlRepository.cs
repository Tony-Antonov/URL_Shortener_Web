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
    public class ShortUrlRepository : IRepository<ShortUrlEntity>
    {
        private readonly IUrlShortenerContext db;
        public ShortUrlRepository(IUrlShortenerContext context)
        {
            db = context;
        }

        public Task<Result> Create(ShortUrlEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ShortUrlEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<ShortUrlEntity>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(ShortUrlEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
