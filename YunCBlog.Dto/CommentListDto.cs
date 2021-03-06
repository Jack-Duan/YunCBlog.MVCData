﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Dto
{
    /// <summary>
    /// 评论列表
    /// </summary>
    public class CommentListDto
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int? CommentId { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 文章ID
        /// </summary>
        public int? ArticleId { get; set; }
        /// <summary>
        /// 父级评论ID
        /// </summary>
        public int? ParentCommentId { get; set; }
        /// <summary>
        /// 用户编号，如果有的话
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 点赞人数
        /// </summary>
        public int? LikeCount { get; set; }
        /// <summary>
        /// 头像图片地址
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 评论人IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? DisOrder { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? IsRemoved { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
