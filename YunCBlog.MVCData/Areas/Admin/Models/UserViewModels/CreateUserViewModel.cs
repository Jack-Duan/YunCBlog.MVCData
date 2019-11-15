using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Areas.Admin.Models.UserViewModels
{
    public class CreateUserViewModel
    {
        [Required, StringLength(maximumLength: 15, MinimumLength = 2), Display(Name = "账号名称")]
        public string UserName { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3), Display(Name = "电子邮箱")]
        public string Email { get; set; }
        [Required, DataType(dataType: DataType.Password), StringLength(18, MinimumLength = 5), Display(Name = "密码")]
        public string PassWord { get; set; }
        [Required, StringLength(30), Display(Name = "网站名称")]
        public string SiteName { get; set; }
    }
}