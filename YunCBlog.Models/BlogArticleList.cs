using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Models
{
    /// <summary>
    /// article列表
    /// </summary>
    public class BlogArticleList : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int? ArticleId { get; set; }
        /// <summary>
        /// 文章所属的模块ID,例如关于我们,游戏人生等..
        /// </summary>
        public int? ArticleTypeLinkId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 主题介绍
        /// </summary>
        public string Theme { get; set; }
        /// <summary>
        /// MarkDown代码内容
        /// </summary>
        public string MarkDownContent { get; set; }
        /// <summary>
        /// 封面名称-带后缀
        /// </summary>
        [Display(Name = "封面名称-带后缀")]
        public string CoverName { get; set; }
        /// <summary>
        /// HTML内容
        /// </summary>
        public string HtmlContent { get; set; }
        /// <summary>
        /// 纯文字内容
        /// </summary>
        public string TextContent { get; set; }
        /// <summary>
        /// 是否发表。1发表，其他草稿
        /// </summary>
        public int? IsPublish { get; set; }
        /// <summary>
        /// 字数
        /// </summary>
        public int? WordNumber { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int? ReadCount { get; set; }
        /// <summary>
        /// 喜欢量
        /// </summary>
        public int? LikeCount { get; set; }
        /// <summary>
        /// 打赏量
        /// </summary>
        public int? TipCount { get; set; }
        /// <summary>
        /// 转载量
        /// </summary>
        public int? ReprintCount { get; set; }
        /// <summary>
        /// 是否可转载.1是2否
        /// </summary>
        public int? IsCanReprint { get; set; }
        /// <summary>
        /// 是否私密1是
        /// </summary>
        public int? IsPrivate { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public int? IsTop { get; set; }

    }
}
