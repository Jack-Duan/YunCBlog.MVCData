using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Dto
{
    /// <summary>
    /// 文章类型与用户模块关联表
    /// </summary>
    public class ArticleType_LinkDto
    {
        /// <summary>
        /// 主键
        /// </summary>
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
