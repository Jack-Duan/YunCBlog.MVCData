using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Dto
{
    /// <summary>
    /// 文章模块表
    /// </summary>
    public class ArticleModuleDto
    {
        /// <summary>
        /// 主键
        /// </summary>
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
        /// 模块简介
        /// </summary>
        public string Theme { get; set; }
        /// <summary>
        /// 父级模块分类ID
        /// </summary>
        public int? ParentModuleId { get; set; }
        /// <summary>
        /// 模块类型。包括个人,企业等，使用字典即可
        /// </summary>
        public int? ArticleTypeId { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }
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
