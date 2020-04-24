using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.Models;

namespace YunCBlog.DAL
{
    public class CommentListService : BaseService<CommentList>, IDAL.ICommentListService
    {
        public CommentListService() : base(new BlogContext())
        {

        }
    }
}
