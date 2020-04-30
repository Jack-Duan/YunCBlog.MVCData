using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
            try
            {
                using (IDAL.IArticleModuleService moduleSvc = new DAL.ArticleModuleService())
                {
                    return await moduleSvc.CreateAsync(new Models.ArticleModuleList
                    {
                        Url = entity.Url,
                        GuId = System.Guid.NewGuid(),
                        ArticleModuleName = entity.ArticleModuleName,
                        ArticleTypeId = entity.ArticleTypeId,
                        DisOrder = entity.DisOrder,
                        Theme = entity.Theme,
                        ParentModuleId = entity.ParentModuleId,
                        IsRemoved = entity.IsRemoved
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EditModel(ArticleModuleDto entity)
        {
            try
            {
                using (IDAL.IArticleModuleService moduleSvc = new DAL.ArticleModuleService())
                {
                    return await moduleSvc.EditAsync(new Models.ArticleModuleList
                    {
                        Url = entity.Url,
                        ArticleModuleId = entity.ArticleModuleId,
                        ArticleModuleName = entity.ArticleModuleName,
                        ArticleTypeId = entity.ArticleTypeId,
                        Theme = entity.Theme,
                        DisOrder = entity.DisOrder,
                        ParentModuleId = entity.ParentModuleId,
                        IsRemoved = entity.IsRemoved
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ArticleModuleDto> GetAllList()
        {
            try
            {
                using (IDAL.IArticleModuleService moduleSvc = new DAL.ArticleModuleService())
                {
                    return moduleSvc.GetAll().Select(e => new Dto.ArticleModuleDto
                    {
                        Url = e.Url,
                        CreateTime = e.CreateTime,
                        ArticleModuleId = e.ArticleModuleId,
                        Theme = e.Theme,
                        ArticleModuleName = e.ArticleModuleName,
                        ArticleTypeId = e.ArticleTypeId,
                        DisOrder = e.DisOrder,
                        ParentModuleId = e.ParentModuleId,
                        IsRemoved = e.IsRemoved
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ArticleModuleDto> GetList(int page, int size)
        {
            try
            {
                using (IDAL.IArticleModuleService moduleSvc = new DAL.ArticleModuleService())
                {
                    return moduleSvc.GetList(page, size).Select(e => new Dto.ArticleModuleDto
                    {
                        Url = e.Url,
                        CreateTime = e.CreateTime,
                        Theme = e.Theme,
                        ArticleModuleId = e.ArticleModuleId,
                        ArticleModuleName = e.ArticleModuleName,
                        ArticleTypeId = e.ArticleTypeId,
                        DisOrder = e.DisOrder,
                        ParentModuleId = e.ParentModuleId,
                        IsRemoved = e.IsRemoved
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ArticleModuleDto> GetListByIds(List<int> ids)
        {
            try
            {
                using (IDAL.IArticleModuleService moduleSvc = new DAL.ArticleModuleService())
                {
                    return moduleSvc.GetAll().Where(e => ids.Contains((int)e.ArticleModuleId)).Select(e => new Dto.ArticleModuleDto
                    {
                        Url = e.Url,
                        CreateTime = e.CreateTime,
                        ArticleModuleId = e.ArticleModuleId,
                        ArticleModuleName = e.ArticleModuleName,
                        ArticleTypeId = e.ArticleTypeId,
                        DisOrder = e.DisOrder,
                        Theme = e.Theme,
                        ParentModuleId = e.ParentModuleId,
                        IsRemoved = e.IsRemoved
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ArticleModuleDto> GetModel(int entityId)
        {
            try
            {
                using (IDAL.IArticleModuleService moduleSvc = new DAL.ArticleModuleService())
                {
                    return await moduleSvc.GetAll().Where(e => e.ArticleModuleId == entityId).Select(e => new Dto.ArticleModuleDto
                    {
                        Url = e.Url,
                        CreateTime = e.CreateTime,
                        ArticleModuleId = e.ArticleModuleId,
                        Theme = e.Theme,
                        ArticleModuleName = e.ArticleModuleName,
                        ArticleTypeId = e.ArticleTypeId,
                        DisOrder = e.DisOrder,
                        ParentModuleId = e.ParentModuleId,
                        IsRemoved = e.IsRemoved
                    }).FirstAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
