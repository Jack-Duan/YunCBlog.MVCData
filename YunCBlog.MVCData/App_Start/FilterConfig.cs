using System.Web;
using System.Web.Mvc;

namespace YunCBlog.MVCData
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorLog() { View = "Error"});
        }
    }
}
