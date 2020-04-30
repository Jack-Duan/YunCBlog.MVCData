using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace YunCBlog.MVCData.Filters
{
    /// <summary>
    /// 监控用户访问记录
    /// </summary>
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
                //var response = Get("https://m.so.com/position?ip=" + ip);
                //var data = JsonConvert.DeserializeObject<IpResult>(response);

                IBLL.IAccessListVistor accessManager = new BLL.AccessListVistor();
                var result = await accessManager.CreateModel(new Dto.AccessListDto
                {
                    IsRemoved = 0,
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
                    //Address = data.data.position.country + "-" + data.data.position.province + "-" + data.data.position.city,
                    //IpResult = response,
                    Server_Name = filterContext.HttpContext.Request.ServerVariables["Server_Name"],
                    Server_Port = filterContext.HttpContext.Request.ServerVariables["Server_Port"]
                }).ConfigureAwait(false);
            }
        }


        public static string Get(string Url)
        {
            //System.GC.Collect();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }

            return retString;
        }
        private class data
        {
            public mso mso { get; set; }
            public string ip { get; set; }
            public position position { get; set; }
        }

        private class mso
        {
            public string x { get; set; }
            public string y { get; set; }
        }
        private class position
        {
            public string province { get; set; }
            public string isp { get; set; }
            public string adcode { get; set; }
            public string area { get; set; }
            public string address { get; set; }
            public string city { get; set; }
            public string city_code { get; set; }
            public string country { get; set; }
            public string street { get; set; }
            public string weathercode { get; set; }
        }

        private class IpResult
        {
            public data data { get; set; }
            public string message { get; set; }
        }
    }
}