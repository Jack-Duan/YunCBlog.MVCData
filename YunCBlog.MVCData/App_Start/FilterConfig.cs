using System.Web;
using System.Web.Mvc;
using YunCBlog.MVCData.Filters;

namespace YunCBlog.MVCData
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorLogAttribute());
            //filters.Add(new HandleErrorAttribute());
        }
    }
}
