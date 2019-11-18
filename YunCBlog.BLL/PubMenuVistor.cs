using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.Dto;
using YunCBlog.IBLL;

namespace YunCBlog.BLL
{
    public class PubMenuVistor : IPubMenuVistor
    {
        public async Task<int> CreateModel(PubMenuDto entity)
        {
            using (IDAL.IPubMenuService menuSvc = new DAL.PubMenuService())
            {
                return await menuSvc.CreateAsync(new Models.PubMenuList
                {
                    MenuName = entity.MenuName,
                    ParentMenuId = entity.ParentMenuId,
                    ModuleId = entity.ModuleId,
                    MenuUrlParam = entity.MenuUrlParam,
                    IsRemoved = entity.IsRemoved,
                    IsLeaf = entity.IsLeaf,
                    ICon = entity.ICon
                });
            }
        }

        public async Task<int> EditModel(PubMenuDto entity)
        {
            using (IDAL.IPubMenuService menuSvc = new DAL.PubMenuService())
            {
                return await menuSvc.CreateAsync(new Models.PubMenuList
                {
                    MenuId = entity.MenuId,
                    MenuName = entity.MenuName,
                    ParentMenuId = entity.ParentMenuId,
                    ModuleId = entity.ModuleId,
                    MenuUrlParam = entity.MenuUrlParam,
                    IsRemoved = entity.IsRemoved,
                    IsLeaf = entity.IsLeaf,
                    ICon = entity.ICon
                });
            }
        }

        public List<PubMenuDto> GetList(int page, int size)
        {
            using (IDAL.IPubMenuService menuSvc = new DAL.PubMenuService())
            {
                return menuSvc.GetList(page, size).Select(e => new PubMenuDto
                {
                    MenuId = e.MenuId,
                    ModuleId = e.ModuleId,
                    GuId = e.GuId,
                    ICon = e.ICon,
                    IsLeaf = e.IsLeaf,
                    IsRemoved = e.IsRemoved,
                    MenuName = e.MenuName,
                    MenuUrlParam = e.MenuUrlParam,
                    ParentMenuId = e.ParentMenuId
                }).ToList();
            }
        }

        public async Task<PubMenuDto> GetModel(int entityId)
        {
            using (IDAL.IPubMenuService menuSvc = new DAL.PubMenuService())
            {
                return await menuSvc.GetAll().Where(e => e.MenuId == entityId).Select(e => new PubMenuDto
                {
                    MenuId = e.MenuId,
                    ModuleId = e.ModuleId,
                    GuId = e.GuId,
                    ICon = e.ICon,
                    IsLeaf = e.IsLeaf,
                    IsRemoved = e.IsRemoved,
                    MenuName = e.MenuName,
                    MenuUrlParam = e.MenuUrlParam,
                    ParentMenuId = e.ParentMenuId
                }).FirstAsync();
            }
        }
    }
}
