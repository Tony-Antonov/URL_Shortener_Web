using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_Common.Models;

namespace URL_Shortener_DAL.Interfaces
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAll();
        Task<T> Get(int id);
        Task<Result> Create(T item);
        Task<Result> Delete(int id);
        Task<Result> Update(T item);
    }
}
