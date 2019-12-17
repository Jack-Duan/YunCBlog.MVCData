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
    public class ArticleModuleVistor : IArticleModuleVistor
    {
        public async Task<int> CreateModel(ArticleModuleDto entity)
        {
            using (IDAL.IArticleModuleService moduleSvc = new DAL.ArticleModuleService())
            {
                return await moduleSvc.CreateAsync(new Models.ArticleModuleList
                {
                    Url=entity.Url,
                    ArticleModuleName = entity.ArticleModuleName,
                    ArticleTypeId = entity.ArticleTypeId,
                    DisOrder = entity.DisOrder,
                    ParentModuleId = entity.ParentModuleId,
                    IsRemoved = entity.IsRemoved
                });
            }
        }

        public async Task<int> EditModel(ArticleModuleDto entity)
        {
            using (IDAL.IArticleModuleService moduleSvc = new DAL.ArticleModuleService())
            {
                return await moduleSvc.EditAsync(new Models.ArticleModuleList
                {
                    Url = entity.Url,
                    ArticleModuleId = entity.ArticleModuleId,
                    ArticleModuleName = entity.ArticleModuleName,
                    ArticleTypeId = entity.ArticleTypeId,
                    DisOrder = entity.DisOrder,
                    ParentModuleId = entity.ParentModuleId,
                    IsRemoved = entity.IsRemoved
                });
            }
        }

        public List<ArticleModuleDto> GetAllList()
        {
            using (IDAL.IArticleModuleService moduleSvc = new DAL.ArticleModuleService())
            {
                return moduleSvc.GetAll().Select(e => new Dto.ArticleModuleDto
                {
                    Url = e.Url,
                    CreateTime = e.CreateTime,
                    ArticleModuleId = e.ArticleModuleId,
                    ArticleModuleName = e.ArticleModuleName,
                    ArticleTypeId = e.ArticleTypeId,
                    DisOrder = e.DisOrder,
                    ParentModuleId = e.ParentModuleId,
                    IsRemoved = e.IsRemoved
                }).ToList();
            }
        }

        public List<ArticleModuleDto> GetList(int page, int size)
        {
            using (IDAL.IArticleModuleService moduleSvc = new DAL.ArticleModuleService())
            {
                return moduleSvc.GetList(page,size).Select(e => new Dto.ArticleModuleDto
                {
                    Url = e.Url,
                    CreateTime = e.CreateTime,
                    ArticleModuleId = e.ArticleModuleId,
                    ArticleModuleName = e.ArticleModuleName,
                    ArticleTypeId = e.ArticleTypeId,
                    DisOrder = e.DisOrder,
                    ParentModuleId = e.ParentModuleId,
                    IsRemoved = e.IsRemoved
                }).ToList();
            }
        }
        public List<ArticleModuleDto> GetListByIds(List<int> ids)
        {
            using (IDAL.IArticleModuleService moduleSvc = new DAL.ArticleModuleService())
            {
                return moduleSvc.GetAll().Where(e=>ids.Contains((int)e.ArticleModuleId)).Select(e => new Dto.ArticleModuleDto
                {
                    Url = e.Url,
                    CreateTime = e.CreateTime,
                    ArticleModuleId = e.ArticleModuleId,
                    ArticleModuleName = e.ArticleModuleName,
                    ArticleTypeId = e.ArticleTypeId,
                    DisOrder = e.DisOrder,
                    ParentModuleId = e.ParentModuleId,
                    IsRemoved = e.IsRemoved
                }).ToList();
            }
        }

        public async Task<ArticleModuleDto> GetModel(int entityId)
        {
            using (IDAL.IArticleModuleService moduleSvc = new DAL.ArticleModuleService())
            {
                return await moduleSvc.GetAll().Where(e=>e.ArticleModuleId==entityId).Select(e => new Dto.ArticleModuleDto
                {
                    Url = e.Url,
                    CreateTime = e.CreateTime,
                    ArticleModuleId = e.ArticleModuleId,
                    ArticleModuleName = e.ArticleModuleName,
                    ArticleTypeId = e.ArticleTypeId,
                    DisOrder = e.DisOrder,
                    ParentModuleId = e.ParentModuleId,
                    IsRemoved = e.IsRemoved
                }).FirstAsync();
            }
        }
    }
}
