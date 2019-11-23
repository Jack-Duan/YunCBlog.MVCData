using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.IDAL;
using YunCBlog.Models;

namespace YunCBlog.DAL
{
    public class ArticleType_LinkService : BaseService<ArticleType_LinkList>, IArticleType_LinkService
    {
        public ArticleType_LinkService() : base(new BlogContext()) { }
    }
}
