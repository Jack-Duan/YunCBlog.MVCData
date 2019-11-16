using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.Dto;
using YunCBlog.IBLL;

namespace YunCBlog.BLL
{
    public class PubMenuVistor : IPubMenuVistor
    {
        public Task<int> CreateModel(PubMenuDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditModel(PubMenuDto entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PubMenuDto> GetList(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<PubMenuDto> GetModel(int entityId)
        {
            throw new NotImplementedException();
        }
    }
}
