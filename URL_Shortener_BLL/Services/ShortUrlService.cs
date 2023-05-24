using HashidsNet;
using URL_Shortener_BLL.Interfaces;
using URL_Shortener_BLL.Models;
using URL_Shortener_Common.Models;
using URL_Shortener_DAL.Entities;
using URL_Shortener_DAL.Interfaces;

namespace URL_Shortener_BLL.Services
{
    public class ShortUrlService : IShortUrlService
    {
        private readonly IUnitOfWork dataBase;
        public ShortUrlService(IUnitOfWork dataBase) {
            this.dataBase = dataBase;
        }

        public async Task<Result> DeleteShortUrl(int id)
        {
            var result = await dataBase.ShortUrls.Delete(id);

            await dataBase.Save();

            return result;
        }

        public async Task<List<ShortUrl>> Get()
        {
            var shortUrlEntities = await dataBase.ShortUrls.Get();
            List<ShortUrl> list = new List<ShortUrl>();
            foreach(var item in shortUrlEntities)
            {
                list.Add(ToDomainModel(item));
            }
            
            return list;
        }

        public async Task<Result> Create(string Url, int userId)
        {
            if (!Uri.IsWellFormedUriString(Url, UriKind.Absolute))
            {
                return new Result("it's not URL", false);
            }
            if ((await dataBase.ShortUrls.Get()).Any(u => u.Url == Url))
            {
                return new Result("This url alreday shorted", false); 
            }
     
            var entity = new ShortUrlEntity()
            {
                UserId = userId,
                CreatedDate = DateTime.Now,
                Url = Url
            };

            await dataBase.ShortUrls.Create(entity);

            await dataBase.Save();
            return new Result("Success", true);
        }

        public async Task<ShortUrl> GetShortUrlById(int id)
        {
            return ToDomainModel(await dataBase.ShortUrls.Get(id));
        }

        public async Task<ShortUrl> GetShortUrlByCode(string code)
        {
            var hashids = new Hashids();
            var result = hashids.TryDecodeSingle(code, out int Id);
            if (!result)
                return null;
            return ToDomainModel(await dataBase.ShortUrls.Get(Id));
        }

        private string generateCode(int Id)
        {
            var hashids = new Hashids();
            string code = hashids.Encode(Id);
            return code;
        }

        private ShortUrl ToDomainModel(ShortUrlEntity shortUrl) 
        {
            return new ShortUrl()
            {
                Id = shortUrl.Id,
                Code = generateCode(shortUrl.Id),
                CreatedDate = shortUrl.CreatedDate,
                CreatedBy = shortUrl.CreatedBy != null ? new User() { 
                    Id= shortUrl.CreatedBy.Id,
                    Username = shortUrl.CreatedBy.UserName,            
                }: null,
                Url = shortUrl.Url,
                ShortedUrl = "https://localhost:7178/" + generateCode(shortUrl.Id)
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
