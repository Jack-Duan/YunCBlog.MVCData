using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Models
{
    /// <summary>
    /// 访问记录
    /// </summary>
    public class AccessList:BaseEntity
    {
        /// <summary>
        /// 主键    
        /// </summary>
        [Key]
        public int AccessId { get; set; }

        /// <summary>
        /// 客户端IP    
        /// </summary>
        public string Remote_Addr { get; set; }

        /// <summary>
        /// IP    
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 客户端主机名    
        /// </summary>
        public string Remote_Host { get; set; }

        /// <summary>
        /// 请求的字符串內容    
        /// </summary>
        public string Http_Referer { get; set; }

        /// <summary>
        /// 接受请求的服务器端口号    
        /// </summary>
        public string Server_Port { get; set; }

        /// <summary>
        /// 客户端浏览器    
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// 浏览器版本号    
        /// </summary>
        public string MajorVersion { get; set; }

        /// <summary>
        /// 客户端操作系统    
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// 服务器IP    
        /// </summary>
        public string Local_Addr { get; set; }

        /// <summary>
        /// 服务器名    
        /// </summary>
        public string Server_Name { get; set; }

        /// <summary>
        /// 访问的页面名    
        /// </summary>
        public string PageName { get; set; }

        /// <summary>
        /// 访问的域名    
        /// </summary>
        public string RealmName { get; set; }
    }
}
