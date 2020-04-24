using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Areas.Admin.Models.ArticleViewModels
{
    public class CommentViewModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Display(Name = "主键")]
        public int? CommentId { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [Display(Name = "用户昵称")]
        public string UserName { get; set; }
        /// <summary>
        /// 文章ID
        /// </summary>
        [Display(Name = "文章ID")]
        public int? ArticleId { get; set; }
        /// <summary>
        /// 父级评论ID
        /// </summary>
        [Display(Name = "父级评论ID")]
        public int? ParentCommentId { get; set; }
        /// <summary>
        /// 用户编号，如果有的话
        /// </summary>
        [Display(Name = "用户编号")]
        public int? UserId { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Display(Name = "内容")]
        public string Content { get; set; }
        /// <summary>
        /// 点赞人数
        /// </summary>
        [Display(Name = "点赞人数")]
        public int? LikeCount { get; set; }
        /// <summary>
        /// 头像图片地址
        /// </summary>
        [Display(Name = "头像图片地址")]
        public string ImgUrl { get; set; }
        /// <summary>
        /// 评论人IP
        /// </summary>
        [Display(Name = "评论人IP")]
        public string IP { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int? DisOrder { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Display(Name = "是否删除")]
        public int? IsRemoved { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }
    }
}