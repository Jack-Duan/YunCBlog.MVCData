using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Models
{
    /// <summary>
    /// 文章类型与用户模块关联表-PubModel
    /// 用于每个用户,每个域名用户有不同的模块,每个模块可以有不同的子级模块.
    /// </summary>
    public class ArticleType_LinkList : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int? ArticleTypeLinkId { get; set; }
        /// <summary>
        /// 文章编号，BlogArticleList主键
        /// </summary>
        public int? ArticleId { get; set; }
        /// <summary>
        /// 文章类型编号，ArticleModuleList主键
        /// </summary>
        public int? ArtcleModuleId { get; set; }
        /// <summary>
        /// 父级文章类型编号
        /// </summary>
        public int? ParentArtcleModuleId { get; set; }
        /// <summary>
        /// 是否使用，1是2否
        /// </summary>
        public int? IsUsed { get; set; }
    }
}
