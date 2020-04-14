using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace YunCBlog.MVCData
{
    public class AdminAreaRouteConfig
    {
        public static void RegisterRoutes(AreaRegistrationContext context)
        {

            context.MapRoute(
                "Admin",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", Controller = "Admin", id = UrlParameter.Optional }
            );
        }
    }
}
