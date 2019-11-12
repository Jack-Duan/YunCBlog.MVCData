using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.Models;

namespace YunCBlog.IDAL
{
    public interface IBaseService<T>:IDisposable where T:BaseEntity
    {
        Task CreateAsync(T model,bool saved=true);
        Task EditAsync(T model,bool saved=true);
        Task RemoveAsync(T model,bool saved=true);
        Task Save();
        Task<T> GetModel(Guid entityId);
        IQueryable<T> GetList(int page, int size, List<string> columns);
        IQueryable<T> GetAll();
    }
}
