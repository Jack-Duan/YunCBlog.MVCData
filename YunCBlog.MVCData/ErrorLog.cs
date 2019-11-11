using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YunCBlog.MVCData
{
    public class ErrorLog : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                //当前Controller名称
                string controllName = (string)filterContext.RouteData.Values["controller"];
                //当前Action
                string actionName = (string)filterContext.RouteData.Values["action"];
                //定义一个HandErrorInfo，用于Error视图展示异常信息
                HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllName, actionName);
                //时间用来给txt命名
                string thisTime = DateTime.Now.ToString("yyyyMMdd");
                string errorDetails = $"出错时间：{DateTime.Now.ToString()},错误发生在{model.ControllerName}控制器的{model.ActionName},错误类型：{model.Exception.Message}";
                string splitLine = "============================下一条==============================";
                //日志存放位置，在项目目录里面一个月一个文件夹，一天一个文件
                string path = HttpContext.Current.Server.MapPath(@"\ErrorLog\" + DateTime.Now.Year.ToString() + @"\" + DateTime.Now.ToString("MM") + @"\");
                //判断文件夹不存在就创建
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                //写入日志
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path + thisTime + ".txt", true))
                {
                    file.WriteLine(errorDetails);
                    file.WriteLine(model.Exception.StackTrace);
                    file.WriteLine(splitLine);

                }
                //出错跳转到指定页面，如果Global.asax写了Application_Error方法可以不用写
                ViewResult result = new ViewResult
                {
                    ViewName = this.View,//设置异常时跳转的404页面
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model)  //定义ViewData，泛型
                };
                filterContext.Result = result;
                filterContext.ExceptionHandled = true;//设置异常已处理
            }
        }
    }
}