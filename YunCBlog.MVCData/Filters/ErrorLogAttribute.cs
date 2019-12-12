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
            if (filterContext.Exception != null)
            {
                //跳转到自定义的错误页
                ActionResult view = new ViewResult() { ViewName = "Error"};
                filterContext.Result = view;

                //异常处理结束后,一定要将ExceptionHandled设置为true,否则仍然会继续抛出错误。
                filterContext.ExceptionHandled = true;

            }
        }
    }
}