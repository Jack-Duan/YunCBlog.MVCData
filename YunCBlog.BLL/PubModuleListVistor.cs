using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.DAL;
using YunCBlog.Dto;
using YunCBlog.IBLL;
using YunCBlog.IDAL;

namespace YunCBlog.BLL
{
    public class PubModuleListVistor : IPubModuleListVistor
    {
        public async Task<int> CreateModel(PubModuleDto entity)
        {
            using (IDAL.IPubModuleListService moduleSvc = new DAL.PubModuleListService())
            {
                return await moduleSvc.CreateAsync(new Models.PubModuleList
                {
                    Url = entity.Url,
                    Memo = entity.Memo,
                    ModuleCode = entity.ModuleCode,
                    ModuleName = entity.ModuleName
                });
            }
        }

        public async Task<int> EditModel(PubModuleDto entity)
        {
            using (IDAL.IPubModuleListService moduleSvc = new DAL.PubModuleListService())
            {
                return await moduleSvc.EditAsync(new Models.PubModuleList
                {
                    ModuleId = entity.ModuleId,
                    Url = entity.Url,
                    Memo = entity.Memo,
                    ModuleCode = entity.ModuleCode,
                    ModuleName = entity.ModuleName
                });
            }

        }

        public List<PubModuleDto> GetAllList()
        {
            using (IDAL.IPubModuleListService moduleSvc = new DAL.PubModuleListService())
            {
                var result = moduleSvc.GetAll().Select(e => new PubModuleDto
                {
                    //GuId = e.GuId,
                    Memo = e.Memo,
                    ModuleCode = e.ModuleCode,
                    ModuleId = e.ModuleId,
                    ModuleName = e.ModuleName,
                    Url = e.Url
                }).ToList();
                return result;
            }
        }

        public List<PubModuleDto> GetList(int page, int size)
        {
            using (IDAL.IPubModuleListService moduleSvc = new DAL.PubModuleListService())
            {
                var result = moduleSvc.GetList(page, size).Select(e => new PubModuleDto
                {
                    GuId = e.GuId,
                    Memo = e.Memo,
                    ModuleCode = e.ModuleCode,
                    ModuleId = e.ModuleId,
                    ModuleName = e.ModuleName,
                    Url = e.Url
                }).ToList();
                return result;
            }
        }
        public List<PubModuleDto> GetListByIds(List<int> ids)
        {
            using (IDAL.IPubModuleListService moduleSvc = new DAL.PubModuleListService())
            {
                var result = moduleSvc.GetAll().Where(e=>ids.Contains((int)e.ModuleId)).Select(e => new PubModuleDto
                {
                    GuId = e.GuId,
                    Memo = e.Memo,
                    ModuleCode = e.ModuleCode,
                    ModuleId = e.ModuleId,
                    ModuleName = e.ModuleName,
                    Url = e.Url
                }).ToList();
                return result;
            }
        }

        public async Task<PubModuleDto> GetModel(Guid guid)
        {
            using (IDAL.IPubModuleListService moduleSvc = new DAL.PubModuleListService())
            {
                var model = await moduleSvc.GetModel(guid);
                return new PubModuleDto
                {
                    GuId = model.GuId,
                    IsRemoved = model.IsRemoved,
                    Memo = model.Memo,
                    ModuleCode = model.ModuleCode,
                    ModuleId = model.ModuleId,
                    ModuleName = model.ModuleName,
                    Url = model.Url
                };
            }
        }
        public async Task<PubModuleDto> GetModel(int entityId)
        {
            using (IDAL.IPubModuleListService moduleSvc = new DAL.PubModuleListService())
            {
                return await moduleSvc.GetAll().Where(e => e.ModuleId == entityId).Select(e => new PubModuleDto
                {
                    GuId = e.GuId,
                    IsRemoved = e.IsRemoved,
                    Memo = e.Memo,
                    ModuleCode = e.ModuleCode,
                    ModuleId = e.ModuleId,
                    ModuleName = e.ModuleName,
                    Url = e.Url
                }).FirstAsync();
            }
        }
    }
}
