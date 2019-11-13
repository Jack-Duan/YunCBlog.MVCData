using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Models.UserViewModels
{
    public class UserCreateInfo
    {

        [Required,MinLength(10), MaxLength(50),Display(Name ="电子邮箱")]
        public string Email { get; set; }
        [Required, MinLength(10), MaxLength(90), Display(Name = "密码")]
        [DataType(dataType: DataType.Password)]
        public string PassWord { get; set; }
        [Required, MinLength(2), MaxLength(30), Display(Name = "网站名称")]
        public string SiteName { get; set; }
        [Required, MinLength(2), MaxLength(30), Display(Name = "用户名称")]
        public string UserName { get; set; }
    }
}