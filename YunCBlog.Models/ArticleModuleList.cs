using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Models
{
    /// <summary>
    /// 模块分类表
    /// </summary>
    public class ArticleModuleList : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int? ArticleModuleId { get; set; }
        /// <summary>
        /// 模块分类名
        /// </summary>
        public string ArticleModuleName { get; set; }
        /// <summary>
        /// 模块链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 父级模块分类名
        /// </summary>
        public int? ParentModuleId { get; set; }
        /// <summary>
        /// 模块类型
        /// </summary>
        public int? ArticleTypeId { get; set; }
    }
}
