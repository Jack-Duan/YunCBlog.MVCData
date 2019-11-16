using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.IDAL;

namespace YunCBlog.DAL
{
    public class PubModuleListService : BaseService<Models.PubModuleList>, IPubModuleListService
    {
        public PubModuleListService() : base(new Models.BlogContext()) { }
    }
}
