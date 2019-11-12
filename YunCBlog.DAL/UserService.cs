using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.IDAL;

namespace YunCBlog.DAL
{
    public class UserService : BaseService<Models.User>, IUserService
    {
        public UserService() : base(new Models.BlogContext()) { }
    }
}
