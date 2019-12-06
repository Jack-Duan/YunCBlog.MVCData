using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YunCBlog.MVCData.Filters
{
    public class ErrorLogAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// 在发生异常时调用
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {



        }
    }
}