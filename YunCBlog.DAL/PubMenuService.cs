using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.DAL;
using YunCBlog.IDAL;

namespace YunCBlog.DAL
{
    public class PubMenuService : BaseService<Models.PubMenuList>, IPubMenuService
    {
        public PubMenuService() : base(new Models.BlogContext()) { }
    }
}
