using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.Models
{
    public class UserList : BaseEntity
    {
        [Key]
        public int? UserId { get; set; }
        [Required, StringLength(300), Column(TypeName = "varchar")]
        public string SiteName { get; set; }
        [Required, StringLength(30), Column(TypeName = "varchar")]
        public string UserName { get; set; }
        [Required, StringLength(300), Column(TypeName = "varchar")]
        public string PassWord { get; set; }
        public string Email { get; set; }
    }
}
