using URL_Shortener_BLL.Models;
using URL_Shortener_Common.Models;

namespace URL_Shortener_BLL.Interfaces
{
    public interface IShortUrlService
    {
        Task<Result> Create(string Url, int userId);
        Task<ShortUrl> GetShortUrlByCode(string code);
        Task<ShortUrl> GetShortUrlById(int id);
        Task<Result> DeleteShortUrl(int id);
        Task<List<ShortUrl>> Get();
    }
}
