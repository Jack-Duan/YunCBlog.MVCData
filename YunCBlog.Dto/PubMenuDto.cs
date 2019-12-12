using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Dto
{
    public class PubMenuDto
    {
        /// <summary>
        /// 主键ID
        /// </summary>
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
        /// <summary>
        /// GuId
        /// </summary>
        public Guid GuId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? IsRemoved { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? DisOrder { get; set; }
    }
}
