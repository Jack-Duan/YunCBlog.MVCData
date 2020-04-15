using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Models
{
    /// <summary>
    /// 用户列表
    /// </summary>
    public class UserList : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int? UserId { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        public int? RoleId { get; set; }
        /// <summary>
        /// 网站名称
        /// </summary>
        //[Required, StringLength(300), Column(TypeName = "varchar")]
        public string SiteName { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        //[Required, StringLength(30), Column(TypeName = "varchar")]
        public string UserName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        //[Required, StringLength(300), Column(TypeName = "varchar")]
        public string Mobile { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
    }
}
