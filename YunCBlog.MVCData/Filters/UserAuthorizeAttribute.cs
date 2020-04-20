using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YunCBlog.MVCData.Filters
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 提供一个入口点用于进行自定义授权检查
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["username"] == null)
            {
                return false;// RedirectToAction(nameof(Index)); ;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {

            ViewResult result = new ViewResult
            {
                ViewName = "LoginUser",//设置异常时跳转的404页面
                ViewData = new ViewDataDictionary<ViewPage>(new ViewPage { })  //定义ViewData，泛型
            };
            filterContext.Result = result;
        }
    }
}