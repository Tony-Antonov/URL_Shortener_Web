using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_BLL.Models;

namespace URL_Shortener_BLL.Interfaces
{
    public interface IShortUrlService
    {
        Task<ShortUrl> Create(ShortUrl shortUrl);
        Task<ShortUrl> GetShortUrl(int id);
        void DeleteShortUrl(int id);
        Task<List<ShortUrl>> Get();
    }
}
