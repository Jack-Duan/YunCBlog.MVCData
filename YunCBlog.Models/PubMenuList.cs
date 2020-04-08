using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Models
{
    /// <summary>
    /// 菜单列表
    /// </summary>
    public class PubMenuList : BaseEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int? MenuId { get; set; }
        /// <summary>
        /// 模块编号
        /// </summary>
        public int? ModuleId { get; set; }
        /// <summary>
        /// 父级菜单编号
        /// </summary>
        public int? ParentMenuId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 地址栏参数
        /// </summary>
        public string MenuUrlParam { get; set; }
        /// <summary>
        /// 是否叶节点。1是2否
        /// </summary>
        public int? IsLeaf { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string ICon { get; set; }
    }
}
