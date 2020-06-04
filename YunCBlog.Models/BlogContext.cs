using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Models
{
    /// <summary>
    /// 连接管理
    /// </summary>
    public class BlogContext : DbContext
    {
        /// <summary>
        /// 连接管理
        /// </summary>
        public BlogContext() : base("conn")
        {
            //从不创建数据库
            Database.SetInitializer<BlogContext>(null);
        }
        /// <summary>
        /// 定义要创建的上下文的模型的生成器。
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //去除表名在数据库中使用复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        /// <summary>
        /// 用户列表
        /// </summary>
        public virtual DbSet<UserList> Users { get; set; }
        /// <summary>
        /// 模块列表
        /// </summary>
        public virtual DbSet<PubModuleList> PubModuleList { get; set; }
        /// <summary>
        /// 菜单列表
        /// </summary>
        public virtual DbSet<PubMenuList> PubMenuList { get; set; }
        /// <summary>
        /// 文章列表
        /// </summary>
        public virtual DbSet<BlogArticleList> BlogArticleList { get; set; }
        /// <summary>
        /// 文章模块
        /// </summary>
        public virtual DbSet<ArticleModuleList> ArticleModuleList { get; set; }
        /// <summary>
        /// 文章类型关联列表
        /// </summary>
        public virtual DbSet<ArticleType_LinkList> ArticleType_LinkList { get; set; }
        /// <summary>
        /// 访问记录列表
        /// </summary>
        public virtual DbSet<AccessList> AccessList { get; set; }
        /// <summary>
        /// 评论列表
        /// </summary>
        public virtual DbSet<CommentList> CommentList { get; set; }
    }
}
