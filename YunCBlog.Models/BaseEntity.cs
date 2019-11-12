using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Models
{
    /// <summary>
    /// 实体表的基类
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public Guid GuId { get; set; } = new Guid();
        /// <summary>
        /// 排序
        /// </summary>
        public int? DisOrder { get; set; } = 100;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool? IsRemoved { get; set; }

    }
}
