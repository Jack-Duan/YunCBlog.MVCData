using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.IDAL;
using YunCBlog.Models;

namespace YunCBlog.DAL
{
    public class ArticleModuleService : BaseService<ArticleModuleList>, IArticleModuleService
    {
        public ArticleModuleService() : base(new BlogContext()) { }
    }
}
