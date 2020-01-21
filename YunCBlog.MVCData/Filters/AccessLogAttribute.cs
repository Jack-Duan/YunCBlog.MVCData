using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YunCBlog.MVCData.Filters
{
    public class AccessLogAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Action调用之前运行
        /// </summary>
        /// <param name="filterContext"></param>
        public async override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //filterContext.HttpContext.Request

            var ip = filterContext.HttpContext.Request.ServerVariables["Remote_Host"];
            if (ip != "218.24.105.82" && !filterContext.HttpContext.Request.IsLocal)
            {

                IBLL.IAccessListVistor accessManager = new BLL.AccessListVistor();
                var result = await accessManager.CreateModel(new Dto.AccessListDto
                {
                    Browser = filterContext.HttpContext.Request.ServerVariables["Browser"],
                    Http_Referer = filterContext.HttpContext.Request.ServerVariables["Http_Referer"],
                    IP = filterContext.HttpContext.Request.ServerVariables["Remote_Host"],
                    Local_Addr = filterContext.HttpContext.Request.ServerVariables["Local_Addr"],
                    PageName = filterContext.HttpContext.Request.Path,
                    MajorVersion = filterContext.HttpContext.Request.ServerVariables["MajorVersion"],
                    RealmName = filterContext.HttpContext.Request.ServerVariables["RealmName"],
                    Remote_Addr = filterContext.HttpContext.Request.ServerVariables["Remote_Addr"],
                    Remote_Host = filterContext.HttpContext.Request.ServerVariables["Remote_Host"],
                    Platform = filterContext.HttpContext.Request.ServerVariables["Platform"],
                    Server_Name = filterContext.HttpContext.Request.ServerVariables["Server_Name"],
                    Server_Port = filterContext.HttpContext.Request.ServerVariables["Server_Port"]
                }).ConfigureAwait(false);
            }
        }
    }
}