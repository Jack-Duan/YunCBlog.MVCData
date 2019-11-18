using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Areas.Admin.Models.PubViewModels
{
    public class PubModuleViewModel
    {
        [Display(Name = "主键")]
        public int? ModuleId { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        [Required, Display(Name = "模块名称")]
        public string ModuleName { get; set; }
        /// <summary>
        /// url地址
        /// </summary>
        [Required, Display(Name = "url地址")]
        public string Url { get; set; }
        /// <summary>
        /// 模块编码
        /// </summary>
        [Required, Display(Name = "模块编码")]
        public string ModuleCode { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Required, Display(Name = "备注")]
        public string Memo { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? IsRemoved { get; set; }
    }
}