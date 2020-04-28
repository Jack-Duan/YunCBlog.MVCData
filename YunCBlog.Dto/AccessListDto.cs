using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Dto
{
    /// <summary>
    /// 访问记录
    /// </summary>
    public class AccessListDto
    {
        /// <summary>
        /// 主键    
        /// </summary>
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
        /// IP地址所属地    
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 查询归属地接口的返回值    
        /// </summary>
        public string IpResult { get; set; }

        /// <summary>
        /// 访问的页面名    
        /// </summary>
        public string PageName { get; set; }

        /// <summary>
        /// 访问的域名    
        /// </summary>
        public string RealmName { get; set; }
        /// <summary>
        /// 唯一标识
        /// </summary>
        public Guid GuId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? DisOrder { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? IsRemoved { get; set; }

    }
}
