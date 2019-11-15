using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YunCBlog.MVCData.Areas.Admin.Models.UserViewModels
{
    public class UserLoginViewModel
    {

        [Required, StringLength(maximumLength: 15, MinimumLength = 2), Display(Name = "账号名称")]
        public string UserName { get; set; }
        [Required, StringLength(18, MinimumLength = 5), Display(Name = "密码")]
        [DataType(dataType: DataType.Password, ErrorMessage = "密码错误！")]
        public string PassWord { get; set; }
    }
}