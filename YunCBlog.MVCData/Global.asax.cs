using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace YunCBlog.MVCData
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            //获取前一个触发到的异常信息
            Exception ex = Server.GetLastError().GetBaseException();
            //将前一个异常信息清除。不清除会触发错误详情页(黄页)。
            Server.ClearError();
            
            //将错误信息返回到客户端
            Response.Write("Error:" + ex.Message);
        }
    }
}
