using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Areas.Admin.Models.PubViewModels
{
    /// <summary>
    /// 访问记录表
    /// </summary>
    public class AccessListViewModel
    {

        /// <summary>
        /// 主键    
        /// </summary>
        [Display(Name = "主键")]
        public int AccessId { get; set; }

        /// <summary>
        /// 客户端IP    
        /// </summary>
        [Display(Name = "客户端IP")]
        public string Remote_Addr { get; set; }

        /// <summary>
        /// IP    
        /// </summary>
        [Display(Name = "IP")]
        public string IP { get; set; }

        /// <summary>
        /// 客户端主机名    
        /// </summary>
        [Display(Name = "客户端主机名")]
        public string Remote_Host { get; set; }

        /// <summary>
        /// 请求的字符串內容    
        /// </summary>
        [Display(Name = "请求的字符串內容")]
        public string Http_Referer { get; set; }

        /// <summary>
        /// 接受请求的服务器端口号    
        /// </summary>
        [Display(Name = "接受请求的服务器端口号")]
        public string Server_Port { get; set; }

        /// <summary>
        /// 客户端浏览器    
        /// </summary>
        [Display(Name = "客户端浏览器")]
        public string Browser { get; set; }

        /// <summary>
        /// 浏览器版本号    
        /// </summary>
        [Display(Name = "浏览器版本号")]
        public string MajorVersion { get; set; }

        /// <summary>
        /// 客户端操作系统    
        /// </summary>
        [Display(Name = "客户端操作系统")]
        public string Platform { get; set; }

        /// <summary>
        /// 服务器IP    
        /// </summary>
        [Display(Name = "服务器IP")]
        public string Local_Addr { get; set; }

        /// <summary>
        /// 服务器名    
        /// </summary>
        [Display(Name = "服务器名")]
        public string Server_Name { get; set; }

        /// <summary>
        /// 访问的页面名    
        /// </summary>
        [Display(Name = "访问的页面名")]
        public string PageName { get; set; }

        /// <summary>
        /// 访问的域名    
        /// </summary>
        [Display(Name = "访问的域名")]
        public string RealmName { get; set; }
        /// <summary>
        /// 唯一标识
        /// </summary>
        [Display(Name = "唯一标识")]
        public Guid GuId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int? DisOrder { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Display(Name = "是否删除")]
        public int? IsRemoved { get; set; }
    }
}