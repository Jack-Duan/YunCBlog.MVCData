using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.IDAL;
using YunCBlog.Models;

namespace YunCBlog.DAL
{
    public class BlogArticleListService : BaseService<BlogArticleList>, IBlogArticleListService
    {
        public BlogArticleListService() : base(new BlogContext())
        {

        }
    }
}
