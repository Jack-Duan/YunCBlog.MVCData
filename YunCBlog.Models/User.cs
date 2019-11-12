using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Models
{
    public class User : BaseEntity
    {
        public int? UserId { get; set; }
        public string SiteName { get; set; }
        public string UserName { get; set; }
    }
}
