using System.Web.Mvc;
using System.Web.Optimization;

namespace YunCBlog.MVCData.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            RegisterRoutes(context);
            RegisterBundles();
        }

        private void RegisterRoutes(AreaRegistrationContext context)
        {
            AdminAreaRouteConfig.RegisterRoutes(context);
        }

        private void RegisterBundles()
        {
            AdminAreaBundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}