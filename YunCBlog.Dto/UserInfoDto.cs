using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Dto
{
    public class UserInfoDto
    {
        public Guid GuId { get; set; }
        public string SiteName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
