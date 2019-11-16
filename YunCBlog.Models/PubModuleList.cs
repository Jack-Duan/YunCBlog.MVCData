using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Models
{
    public class PubModuleList:BaseEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int? ModuleId { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// url地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 模块编码
        /// </summary>
        public string ModuleCode { get; set; }
    }
}
