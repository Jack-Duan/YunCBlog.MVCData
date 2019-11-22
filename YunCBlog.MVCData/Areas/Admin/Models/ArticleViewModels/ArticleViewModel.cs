using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Areas.Admin.Models.ArticleViewModels
{
    public class ArticleViewModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name = "主键")]
        public int? ArticleId { get; set; }
        /// <summary>
        /// 文章所属的模块ID,例如关于我们,游戏人生等..
        /// </summary>
        [Display(Name = "文章所属的模块ID")]
        public int? ArticleTypeLinkId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required, Display(Name = "标题"), MaxLength(70)]
        public string Title { get; set; }
        /// <summary>
        /// MarkDown代码内容
        /// </summary>
        [Display(Name = "MarkDown代码内容")]
        public string MarkDownContent { get; set; }
        /// <summary>
        /// HTML内容
        /// </summary>
        [Required, Display(Name = "HTML内容")]
        public string HtmlContent { get; set; }
        /// <summary>
        /// 纯文字内容
        /// </summary>
        [Required, Display(Name = "纯文字内容")]
        public string TextContent { get; set; }
        /// <summary>
        /// 是否发表。1发表，其他草稿
        /// </summary>
        [Display(Name = "是否发表")]
        public int? IsPublish { get; set; }
        /// <summary>
        /// 字数
        /// </summary>
        [Display(Name = "字数")]
        public int? WordNumber { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        [Display(Name = "浏览量")]
        public int? ReadCount { get; set; }
        /// <summary>
        /// 喜欢量
        /// </summary>
        [Display(Name = "喜欢量")]
        public int? LikeCount { get; set; }
        /// <summary>
        /// 打赏量
        /// </summary>
        [Display(Name = "打赏量")]
        public int? TipCount { get; set; }
        /// <summary>
        /// 转载量
        /// </summary>
        [Display(Name = "转载量")]
        public int? ReprintCount { get; set; }
        /// <summary>
        /// 是否可转载.1是2否
        /// </summary>
        [Display(Name = "是否可转载")]
        public int? IsCanReprint { get; set; }
        /// <summary>
        /// 是否私密1是
        /// </summary>
        [Display(Name = "是否私密")]
        public int? IsPrivate { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        [Display(Name = "是否置顶")]
        public int? IsTop { get; set; }
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
    }
}