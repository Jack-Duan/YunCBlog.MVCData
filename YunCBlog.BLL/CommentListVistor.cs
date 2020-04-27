using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.Dto;

namespace YunCBlog.BLL
{
    /// <summary>
    /// 
    /// </summary>
    public class CommentListVistor : IBLL.ICommentListVistor
    {
        public async Task<int> CreateModel(CommentListDto entity)
        {
            using (IDAL.ICommentListService commentSvc = new DAL.CommentListService())
            {
                return await commentSvc.CreateAsync(new Models.CommentList
                {
                    UserId = entity.UserId,
                    Content = entity.Content,
                    CreateTime = DateTime.Now,
                    DisOrder = entity.DisOrder,
                    ImgUrl = entity.ImgUrl,
                    ArticleId = entity.ArticleId,
                    IP = entity.IP,
                    IsRemoved = entity.IsRemoved,
                    LikeCount = entity.LikeCount,
                    UserName = entity.UserName,
                    ParentCommentId = entity.ParentCommentId,
                    GuId = System.Guid.NewGuid()
                });
            }
        }


        public async Task<int> EditModel(CommentListDto entity)
        {
            using (IDAL.ICommentListService commentSvc = new DAL.CommentListService())
            {
                //var model = await commentSvc.GetAll().Where(e => e.CommentId == entity.CommentId).FirstOrDefaultAsync();
                return await commentSvc.EditAsync(new Models.CommentList
                {
                    UserId = entity.UserId,
                    Content = entity.Content,
                    ArticleId = entity.ArticleId,
                    DisOrder = entity.DisOrder,
                    ImgUrl = entity.ImgUrl,
                    IP = entity.IP,
                    //GuId = model.GuId,
                    UserName = entity.UserName,
                    IsRemoved = entity.IsRemoved,
                    LikeCount = entity.LikeCount,
                    ParentCommentId = entity.ParentCommentId,
                    CommentId = entity.CommentId,
                });
            }
        }

        public List<CommentListDto> GetAllList()
        {
            using (IDAL.ICommentListService articleSvc = new DAL.CommentListService())
            {
                return articleSvc.GetAll().Select(entity => new CommentListDto
                {
                    UserId = entity.UserId,
                    Content = entity.Content,
                    ArticleId = entity.ArticleId,
                    CreateTime = entity.CreateTime,
                    DisOrder = entity.DisOrder,
                    ImgUrl = entity.ImgUrl,
                    //GuId = entity.GuId,
                    IP = entity.IP,
                    UserName = entity.UserName,
                    IsRemoved = entity.IsRemoved,
                    LikeCount = entity.LikeCount,
                    ParentCommentId = entity.ParentCommentId,
                    CommentId = entity.CommentId,
                }).ToList();
            }
        }

        public List<CommentListDto> GetList(int page, int size)
        {
            using (IDAL.ICommentListService menuSvc = new DAL.CommentListService())
            {
                return menuSvc.GetAll().Where(e => e.IsRemoved == 0).Select(entity => new CommentListDto
                {
                    UserId = entity.UserId,
                    ArticleId = entity.ArticleId,
                    Content = entity.Content,
                    CreateTime = entity.CreateTime,
                    DisOrder = entity.DisOrder,
                    ImgUrl = entity.ImgUrl,
                    //GuId = entity.GuId,
                    IP = entity.IP,
                    UserName = entity.UserName,
                    IsRemoved = entity.IsRemoved,
                    LikeCount = entity.LikeCount,
                    ParentCommentId = entity.ParentCommentId,
                    CommentId = entity.CommentId,
                }).ToList();
            }
        }

        public async Task<CommentListDto> GetModel(int entityId)
        {
            using (IDAL.ICommentListService menuSvc = new DAL.CommentListService())
            {
                return await menuSvc.GetAll().Where(e => e.CommentId == entityId).Select(entity => new CommentListDto
                {
                    UserId = entity.UserId,
                    Content = entity.Content,
                    CreateTime = entity.CreateTime,
                    ArticleId = entity.ArticleId,
                    DisOrder = entity.DisOrder,
                    ImgUrl = entity.ImgUrl,
                    IP = entity.IP,
                   // GuId = entity.GuId,
                    UserName = entity.UserName,
                    IsRemoved = entity.IsRemoved,
                    LikeCount = entity.LikeCount,
                    ParentCommentId = entity.ParentCommentId,
                    CommentId = entity.CommentId,
                }).FirstAsync();
            }
        }
    }
}
