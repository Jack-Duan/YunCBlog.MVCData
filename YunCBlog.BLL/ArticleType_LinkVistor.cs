﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.Dto;
using YunCBlog.IBLL;

namespace YunCBlog.BLL
{
    public class ArticleType_LinkVistor : IArticleType_LinkVistor
    {
        public async Task<int> CreateModel(ArticleType_LinkDto entity)
        {
            try
            {
                using (IDAL.IArticleType_LinkService articleAvg = new DAL.ArticleType_LinkService())
                {
                    return await articleAvg.CreateAsync(new Models.ArticleType_LinkList
                    {
                        ArticleId = entity.ArticleId,
                        ArtcleModuleId = entity.ArtcleModuleId,
                        IsUsed = entity.IsUsed,
                        GuId = System.Guid.NewGuid(),
                        ParentArtcleModuleId = entity.ParentArtcleModuleId,
                        CreateTime = entity.CreateTime,
                        DisOrder = entity.DisOrder,
                        IsRemoved = entity.IsRemoved
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EditModel(ArticleType_LinkDto entity)
        {
            try
            {
                using (IDAL.IArticleType_LinkService articleAvg = new DAL.ArticleType_LinkService())
                {
                    return await articleAvg.EditAsync(new Models.ArticleType_LinkList
                    {
                        ArticleTypeLinkId = entity.ArticleTypeLinkId,
                        ArticleId = entity.ArticleId,
                        ArtcleModuleId = entity.ArtcleModuleId,
                        IsUsed = entity.IsUsed,
                        ParentArtcleModuleId = entity.ParentArtcleModuleId,
                        DisOrder = entity.DisOrder,
                        IsRemoved = entity.IsRemoved
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ArticleType_LinkDto> GetAllList()
        {
            try
            {
                using (IDAL.IArticleType_LinkService articleAvg = new DAL.ArticleType_LinkService())
                {
                    return articleAvg.GetAll().Select(e => new ArticleType_LinkDto
                    {
                        ArticleTypeLinkId = e.ArticleTypeLinkId,
                        ArticleId = e.ArticleId,
                        ArtcleModuleId = e.ArtcleModuleId,
                        IsUsed = e.IsUsed,
                        ParentArtcleModuleId = e.ParentArtcleModuleId,
                        CreateTime = e.CreateTime,
                        DisOrder = e.DisOrder,
                        IsRemoved = e.IsRemoved
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ArticleType_LinkDto> GetList(int page, int size)
        {
            try
            {
                using (IDAL.IArticleType_LinkService articleAvg = new DAL.ArticleType_LinkService())
                {
                    return articleAvg.GetList(page, size).Select(e => new ArticleType_LinkDto
                    {
                        ArticleTypeLinkId = e.ArticleTypeLinkId,
                        ArtcleModuleId = e.ArtcleModuleId,
                        ArticleId = e.ArticleId,
                        IsUsed = e.IsUsed,
                        ParentArtcleModuleId = e.ParentArtcleModuleId,
                        CreateTime = e.CreateTime,
                        DisOrder = e.DisOrder,
                        IsRemoved = e.IsRemoved
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ArticleType_LinkDto> GetModel(int entityId)
        {
            try
            {
                using (IDAL.IArticleType_LinkService articleAvg = new DAL.ArticleType_LinkService())
                {
                    return await articleAvg.GetAll().Where(e => e.ArticleTypeLinkId == entityId).Select(e => new ArticleType_LinkDto
                    {
                        ArticleTypeLinkId = e.ArticleTypeLinkId,
                        ArtcleModuleId = e.ArtcleModuleId,
                        ArticleId = e.ArticleId,
                        IsUsed = e.IsUsed,
                        ParentArtcleModuleId = e.ParentArtcleModuleId,
                        CreateTime = e.CreateTime,
                        DisOrder = e.DisOrder,
                        IsRemoved = e.IsRemoved
                    }).FirstAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Dto.ArticleType_LinkDto>> GetListByIds(List<int> entityIds)
        {
            try
            {
                using (IDAL.IArticleType_LinkService articleAvg = new DAL.ArticleType_LinkService())
                {
                    return await articleAvg.GetAll().Where(e => entityIds.Contains((int)e.ArticleTypeLinkId)).Select(e => new ArticleType_LinkDto
                    {
                        ArticleTypeLinkId = e.ArticleTypeLinkId,
                        ArtcleModuleId = e.ArtcleModuleId,
                        ArticleId = e.ArticleId,
                        IsUsed = e.IsUsed,
                        ParentArtcleModuleId = e.ParentArtcleModuleId,
                        CreateTime = e.CreateTime,
                        DisOrder = e.DisOrder,
                        IsRemoved = e.IsRemoved
                    }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
