using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Areas.Admin.Models.ArticleViewModels
{
    public class ArticleModuleViewModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name = "主键")]
        public int? ArticleModuleId { get; set; }
        /// <summary>
        /// 模块分类名
        /// </summary>
        [Display(Name = "模块分类名")]
        public string ArticleModuleName { get; set; }
        /// <summary>
        /// 模块链接
        /// </summary>
        [Display(Name = "模块链接")]
        public string Url { get; set; }
        /// <summary>
        /// 父级模块分类ID
        /// </summary>
        [Display(Name = "父级模块分类ID")]
        public int? ParentModuleId { get; set; }
        /// <summary>
        /// 模块类型。包括个人,企业等，使用字典即可
        /// </summary>
        [Display(Name = "模块类型")]
        public int? ArticleTypeId { get; set; }
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