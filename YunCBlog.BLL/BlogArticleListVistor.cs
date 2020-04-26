using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.Dto;
using YunCBlog.IBLL;
using YunCBlog.Models;

namespace YunCBlog.BLL
{
    public class BlogArticleListVistor : IBlogArticleListVistor
    {
        public async Task<int> CreateModel(BlogArticleListDto entity)
        {
            using (IDAL.IBlogArticleListService articleSvc = new DAL.BlogArticleListService())
            {
                return await articleSvc.CreateAsync(new Models.BlogArticleList
                {
                    ArticleTypeLinkId = entity.ArticleTypeLinkId ?? 0,
                    HtmlContent = entity.HtmlContent,
                    IsCanReprint = entity.IsCanReprint,
                    IsPrivate = entity.IsPrivate ?? 0,
                    IsPublish = entity.IsPublish ?? 0,
                    IsRemoved = entity.IsRemoved ?? 0,
                    IsTop = entity.IsTop ?? 0,
                    GuId = System.Guid.NewGuid(),
                    MarkDownContent = entity.MarkDownContent,
                    LikeCount = entity.LikeCount ?? 0,
                    ReadCount = entity.ReadCount ?? 0,
                    ReprintCount = entity.ReprintCount ?? 0,
                    TextContent = entity.TextContent,
                    TipCount = entity.TipCount ?? 0,
                    CoverName = entity.CoverName,
                    Title = entity.Title,
                    Theme = entity.Theme,
                    WordNumber = entity.WordNumber ?? 0,
                    ArticleModuleId = entity.ArticleModuleId
                });
            }
        }


        public async Task<int> EditModel(BlogArticleListDto entity)
        {
            using (IDAL.IBlogArticleListService articleSvc = new DAL.BlogArticleListService())
            {
                var model =await articleSvc.GetAll().Where(e => e.ArticleId == entity.ArticleId).FirstOrDefaultAsync();
                return await articleSvc.EditAsync(new Models.BlogArticleList
                {
                    ArticleTypeLinkId = entity.ArticleTypeLinkId,
                    HtmlContent = entity.HtmlContent,
                    IsCanReprint = entity.IsCanReprint,
                    IsPrivate = entity.IsPrivate,
                    IsPublish = entity.IsPublish,
                    IsRemoved = entity.IsRemoved,
                    IsTop = entity.IsTop,
                    MarkDownContent = entity.MarkDownContent,
                    LikeCount = entity.LikeCount,
                    ReadCount = entity.ReadCount,
                    ReprintCount = entity.ReprintCount,
                    TextContent = entity.TextContent,
                    TipCount = entity.TipCount,
                    CreateTime = model?.CreateTime ?? DateTime.Now,
                    Title = entity.Title,
                    CoverName = entity.CoverName,
                    Theme = entity.Theme,
                    DisOrder = entity.DisOrder,
                    WordNumber = entity.WordNumber,
                    ArticleModuleId = entity.ArticleModuleId,
                    ArticleId = entity.ArticleId
                });
            }
        }

        public List<BlogArticleListDto> GetAllList()
        {
            using (IDAL.IBlogArticleListService articleSvc = new DAL.BlogArticleListService())
            {
                return articleSvc.GetAll().Select(e => new BlogArticleListDto
                {
                    ArticleTypeLinkId = e.ArticleTypeLinkId,
                    HtmlContent = e.HtmlContent,
                    IsCanReprint = e.IsCanReprint,
                    IsPrivate = e.IsPrivate,
                    IsPublish = e.IsPublish,
                    IsRemoved = e.IsRemoved,
                    IsTop = e.IsTop,
                    MarkDownContent = e.MarkDownContent,
                    LikeCount = e.LikeCount,
                    ReadCount = e.ReadCount,
                    ReprintCount = e.ReprintCount,
                    TextContent = e.TextContent,
                    TipCount = e.TipCount,
                    Title = e.Title,
                    CoverName = e.CoverName,
                    Theme = e.Theme,
                    ArticleModuleId = e.ArticleModuleId,
                    DisOrder = e.DisOrder,
                    CreateTime = e.CreateTime,
                    WordNumber = e.WordNumber,
                    ArticleId = e.ArticleId
                }).ToList();
            }
        }

        public List<BlogArticleListDto> GetList(int page, int size)
        {
            using (IDAL.IBlogArticleListService articleSvc = new DAL.BlogArticleListService())
            {
                return articleSvc.GetList(page, size).Select(e => new BlogArticleListDto
                {
                    ArticleTypeLinkId = e.ArticleTypeLinkId,
                    HtmlContent = e.HtmlContent,
                    IsCanReprint = e.IsCanReprint,
                    IsPrivate = e.IsPrivate,
                    IsPublish = e.IsPublish,
                    IsRemoved = e.IsRemoved,
                    IsTop = e.IsTop,
                    Theme = e.Theme,
                    CoverName = e.CoverName,
                    MarkDownContent = e.MarkDownContent,
                    LikeCount = e.LikeCount,
                    ReadCount = e.ReadCount,
                    ReprintCount = e.ReprintCount,
                    TextContent = e.TextContent,
                    TipCount = e.TipCount,
                    ArticleModuleId = e.ArticleModuleId,
                    Title = e.Title,
                    DisOrder = e.DisOrder,
                    WordNumber = e.WordNumber,
                    CreateTime = e.CreateTime,
                    ArticleId = e.ArticleId
                }).ToList();
            }
        }
        public List<BlogArticleListDto> GetListByIds(List<int> ids)
        {
            using (IDAL.IBlogArticleListService articleSvc = new DAL.BlogArticleListService())
            {
                return articleSvc.GetAll().Where(e => ids.Contains((int)e.ArticleId)).Select(e => new BlogArticleListDto
                {
                    ArticleTypeLinkId = e.ArticleTypeLinkId,
                    HtmlContent = e.HtmlContent,
                    IsCanReprint = e.IsCanReprint,
                    IsPrivate = e.IsPrivate,
                    IsPublish = e.IsPublish,
                    IsRemoved = e.IsRemoved,
                    IsTop = e.IsTop,
                    Theme = e.Theme,
                    CoverName = e.CoverName,
                    MarkDownContent = e.MarkDownContent,
                    LikeCount = e.LikeCount,
                    ReadCount = e.ReadCount,
                    ReprintCount = e.ReprintCount,
                    ArticleModuleId = e.ArticleModuleId,
                    TextContent = e.TextContent,
                    TipCount = e.TipCount,
                    Title = e.Title,
                    DisOrder = e.DisOrder,
                    WordNumber = e.WordNumber,
                    CreateTime = e.CreateTime,
                    ArticleId = e.ArticleId
                }).ToList();
            }
        }

        public async Task<BlogArticleListDto> GetModel(int entityId)
        {
            using (IDAL.IBlogArticleListService articleSvc = new DAL.BlogArticleListService())
            {
                return await articleSvc.GetAll().Where(e => e.ArticleId == entityId).Select(e => new BlogArticleListDto
                {
                    ArticleTypeLinkId = e.ArticleTypeLinkId,
                    HtmlContent = e.HtmlContent,
                    IsCanReprint = e.IsCanReprint,
                    ArticleModuleId = e.ArticleModuleId,
                    IsPrivate = e.IsPrivate,
                    IsPublish = e.IsPublish,
                    IsRemoved = e.IsRemoved,
                    IsTop = e.IsTop,
                    CoverName = e.CoverName,
                    Theme = e.Theme,
                    MarkDownContent = e.MarkDownContent,
                    LikeCount = e.LikeCount,
                    ReadCount = e.ReadCount,
                    ReprintCount = e.ReprintCount,
                    TextContent = e.TextContent,
                    TipCount = e.TipCount,
                    Title = e.Title,
                    DisOrder = e.DisOrder,
                    WordNumber = e.WordNumber,
                    CreateTime = e.CreateTime,
                    ArticleId = e.ArticleId
                }).FirstAsync();
            }
        }
    }
}
