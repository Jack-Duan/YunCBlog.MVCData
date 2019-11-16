using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.IBLL
{
    public interface IPubModuleListVistor
    {
        Task<int> CreateModel(Dto.PubModuleDto entity);
        List<Dto.PubModuleDto> GetList(int page, int size);
        List<Dto.PubModuleDto> GetAllList();
        Task<Dto.PubModuleDto> GetModel(Guid guid);
        Task<Dto.PubModuleDto> GetModel(int entityId);
        Task<int> EditModel(Dto.PubModuleDto entity);
    }
}
