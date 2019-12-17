using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Dto
{
    /// <summary>
    /// 文章列表
    /// </summary>
    public class BlogArticleListDto
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
        /// 文章所属模块主键
        /// </summary>
        [Display(Name = "文章所属模块主键")]
        public int? ArticleModuleId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required, Display(Name = "标题")]
        public string Title { get; set; }
        /// <summary>
        /// 封面名称-带后缀
        /// </summary>
        [Display(Name = "封面名称-带后缀")]
        public string CoverName { get; set; }
        /// <summary>
        /// 主题介绍
        /// </summary>
        [Display(Name = "介绍")]
        public string Theme { get; set; }
        /// <summary>
        /// MarkDown代码内容
        /// </summary>
        [Display(Name = "主键")]
        public string MarkDownContent { get; set; }
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
