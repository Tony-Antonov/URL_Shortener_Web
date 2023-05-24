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
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly IUrlShortenerContext db;
        public ShortUrlRepository(IUrlShortenerContext context)
        {
            db = context;
        }

        public async Task<ShortUrlEntity> Create(ShortUrlEntity item)
        {
            var res = await db.shortUrls.AddAsync(item);
            return res.Entity;      
        }

        public async Task<Result> Delete(int id)
        {
            var res = db.shortUrls.Remove(db.shortUrls.Single(i => i.Id == id));
            return new Result("completed", true);
        }

        public async Task<ShortUrlEntity> Get(int id)
        {
            var res = await db.shortUrls.Include(u => u.CreatedBy).SingleAsync(i => i.Id == id);
            return res;
        }

        public async Task<IEnumerable<ShortUrlEntity>> Get()
        {
            return await db.shortUrls.Include(u => u.CreatedBy).ToListAsync();
        }
    }
}
