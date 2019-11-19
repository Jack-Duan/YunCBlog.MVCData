using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Areas.Admin.Models.PubViewModels
{
    public class ShowMenuViewModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Display(Name = "主键ID")]
        public int? MenuId { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        [Display(Name = "Url")]
        public string Url { get; set; }
        /// <summary>
        /// 父级菜单编号
        /// </summary>
        [Display(Name = "父级菜单编号")]
        public int? ParentMenuId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Display(Name = "菜单名称")]
        public string MenuName { get; set; }
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
    }
}