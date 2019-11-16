using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Dto
{
    public class PubModuleDto
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Display(Name = "主键ID")]
        public int? ModuleId { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        [Display(Name = "模块名称")]
        public string ModuleName { get; set; }
        /// <summary>
        /// url地址
        /// </summary>
        [Display(Name = "url地址")]
        public string Url { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Memo { get; set; }
        /// <summary>
        /// 模块编码
        /// </summary>
        [Display(Name = "模块编码")]
        public string ModuleCode { get; set; }
        /// <summary>
        /// GuId
        /// </summary>
        [Display(Name = "GuId")]
        public Guid GuId { get; set; }
    }
}
