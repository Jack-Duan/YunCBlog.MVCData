using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Areas.Admin.Models.PubViewModels
{
    public class PubMenuViewModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Display(Name = "主键ID")]
        public int? MenuId { get; set; }
        /// <summary>
        /// 模块编号
        /// </summary>
        [Required, Display(Name = "模块编号")]
        public int? ModuleId { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        [Display(Name = "模块名称")]
        public string ModuleName { get; set; }
        /// <summary>
        /// 父级菜单编号
        /// </summary>
        [Display(Name = "父级菜单编号")]
        public int? ParentMenuId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required, Display(Name = "菜单名称")]
        public string MenuName { get; set; }
        /// <summary>
        /// 父级菜单名称
        /// </summary>
        [Display(Name = "父级菜单名称")]
        public string ParentMenuName { get; set; }
        /// <summary>
        /// 地址栏参数
        /// </summary>
        [Display(Name = "地址栏参数")]
        public string MenuUrlParam { get; set; }
        /// <summary>
        /// 是否叶节点。1是2否
        /// </summary>
        [Display(Name = "是否叶节点")]
        public int? IsLeaf { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [Display(Name = "图标")]
        public string ICon { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Display(Name = "是否删除")]
        public int? IsRemoved { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int? DisOrder { get; set; }
    }
}