using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Areas.Admin.Models.ArticleViewModels
{
    public class ArticleTypeLinkViewModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name = "主键")]
        public int? ArticleTypeLinkId { get; set; }
        /// <summary>
        /// 文章编号，BlogArticleList主键
        /// </summary>
        [Required, Display(Name = "文章编号")]
        public int? ArticleId { get; set; }
        /// <summary>
        /// 文章类型编号，ArticleModuleList主键
        /// </summary>
        [Display(Name = "文章类型编号")]
        public int? ArtcleModuleId { get; set; }
        /// <summary>
        /// 父级文章类型编号
        /// </summary>
        [Display(Name = "父级文章类型编号")]
        public int? ParentArtcleModuleId { get; set; }
        /// <summary>
        /// 是否使用，1是2否
        /// </summary>
        [Display(Name = "是否使用")]
        public int? IsUsed { get; set; }
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