using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.IBLL
{
    public interface IPubMenuVistor
    {
        Task<int> CreateModel(Dto.PubMenuDto entity);
        IQueryable<Dto.PubMenuDto> GetList(int page, int size);
        Task<Dto.PubMenuDto> GetModel(int entityId);
        Task<int> EditModel(Dto.PubMenuDto entity);
    }
}
