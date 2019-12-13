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
            //��ȡǰһ�����������쳣��Ϣ
            Exception ex = Server.GetLastError().GetBaseException();
            //��ǰһ���쳣��Ϣ�����������ᴥ����������ҳ(��ҳ)��
            Server.ClearError();
            
            //��������Ϣ���ص��ͻ���
            Response.Write("Error:" + ex.Message);
        }
    }
}
