using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Models.ApplicationViewModels
{
    public class MenuViewModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? MenuId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 模块链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 子级列表
        /// </summary>
        public List<MenuViewModel> ChildMenuViewModel { get; set; }
    }
}