using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.IDAL;
using YunCBlog.Models;

namespace YunCBlog.DAL
{
    public class AccessListService : BaseService<AccessList>, IAccessListService
    {
        public AccessListService() : base(new BlogContext()) { }
    }
}
