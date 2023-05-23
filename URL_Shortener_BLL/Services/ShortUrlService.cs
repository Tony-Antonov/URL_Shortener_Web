using HashidsNet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_BLL.Interfaces;
using URL_Shortener_BLL.Models;
using URL_Shortener_DAL.Entities;
using URL_Shortener_DAL.Interfaces;

namespace URL_Shortener_BLL.Services
{
    public class ShortUrlService : IShortUrlService
    {
        private readonly IUnitOfWork DataBase;
        public ShortUrlService(IUnitOfWork dataBase) {
            DataBase = dataBase;
        }

        public void DeleteShortUrl(int id)
        {
            DataBase.ShortUrls.Delete(id);
        }

        public async Task<List<ShortUrl>> Get()
        {
            var a = await DataBase.ShortUrls.Get();
            List<ShortUrl> list = new List<ShortUrl>();
            foreach(var item in a)
            {
                list.Add(ToDomainModel(item));
            }
            
            return list;
        }

        public async Task<ShortUrl> Create(ShortUrl shortUrl)
        {
            var a = await DataBase.ShortUrls.Create(ToEntityModel(shortUrl));
            return ToDomainModel(a);
        }

        public async Task<ShortUrl> GetShortUrl(int id)
        {  
            return ToDomainModel(await DataBase.ShortUrls.Get(id));
        }

        private string generateCode(int Id)
        {
            var hashids = new Hashids();
            string code = hashids.Encode(Id);
            return code;
        }

        private int GetIdbyCode(string code)
        {
            var hashids = new Hashids();
            int Id = hashids.DecodeSingle(code);
            return Id;
        }

        private ShortUrl ToDomainModel(ShortUrlEntity shortUrl) 
        {
            return new ShortUrl()
            {
                Id = shortUrl.Id,
                Code = generateCode(shortUrl.Id),
                CreatedDate = shortUrl.CreatedDate,
                CreatedBy = null,
                Url = shortUrl.Url,
            };     
        }

        private ShortUrlEntity ToEntityModel(ShortUrl shortUrl)
        {
            return new ShortUrlEntity()
            {

                Id = shortUrl.Id,
                CreatedDate = shortUrl.CreatedDate,
                Url = shortUrl.Url,
                UserId = shortUrl.CreatedBy.Id
            };
        }

    }
}
