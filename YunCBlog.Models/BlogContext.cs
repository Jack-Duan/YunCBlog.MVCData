using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("conn")
        {
            //从不创建数据库
            Database.SetInitializer<BlogContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //去除表名在数据库中使用复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        public virtual DbSet<UserList> Users { get; set; }
        public virtual DbSet<PubModuleList> PubModuleList { get; set; }
        public virtual DbSet<PubMenuList> PubMenuList { get; set; }
        public virtual DbSet<BlogArticleList> BlogArticleList { get; set; }
    }
}
