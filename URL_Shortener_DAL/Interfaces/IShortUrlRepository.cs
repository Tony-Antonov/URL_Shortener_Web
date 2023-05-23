using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_Common.Models;
using URL_Shortener_DAL.Entities;

namespace URL_Shortener_DAL.Interfaces
{
    public interface IShortUrlRepository
    {
        Task<IEnumerable<ShortUrlEntity>> Get(); //Change IEnumarable
        Task<ShortUrlEntity> Get(int id);
        Task<ShortUrlEntity> Create(ShortUrlEntity item);
        Task<Result> Delete(int id);
    }
}
