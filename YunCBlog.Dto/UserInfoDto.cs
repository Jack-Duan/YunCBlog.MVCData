using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Dto
{
    public class UserInfoDto
    {
        public string SiteName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Mobile { get; set; }
        public int? RoleId { get; set; }
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
