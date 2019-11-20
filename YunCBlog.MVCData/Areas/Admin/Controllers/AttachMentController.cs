using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YunCBlog.MVCData.Areas.Admin.Controllers
{
    public class AttachMentController : Controller
    {
        // GET: Admin/AttachMent
        public ActionResult Index()
        {
            return View();
        }
        //Admin/AttachMent/UploadFile
        [HttpPost]
        public string UploadFile()
        {
            var files = HttpContext.Request.Files;

            var result = "";
            if (files.Count > 0)
            {
                var fileContent = files["file"];
                //文件大小   
                long size = fileContent.ContentLength;
                //文件类型   
                string type = fileContent.ContentType;
                //文件名   
                string name = fileContent.FileName;
                //文件格式   
                string _tp = Path.GetExtension(name);
                var imagesExtensions = new List<string> { ".jpg", ".jpeg" , ".gif" , ".png", ".swf" };
                var videoExtensions = new List<string> { ".mp4", ".flv", ".avi", ".rm", ".rmvb" };
                if (imagesExtensions.Contains(_tp))
                {
                    //本站点的存储位置
                    var imagePath = "\\Attachment\\images\\";
                    string AbsolutePath = HttpContext.Server.MapPath(imagePath);
                    if (!Directory.Exists(AbsolutePath))//路径不存在就创建这个文件夹
                    {
                        Directory.CreateDirectory(AbsolutePath);
                    }
                    var lastImagePath = AbsolutePath + name;
                    fileContent.SaveAs(lastImagePath);
                    return JsonConvert.SerializeObject(new
                    {
                        code = 1,
                        msg = "上传成功",
                        data = new
                        {
                            src = imagePath + name,
                            title = ""
                        }
                    });
                }
                else if (videoExtensions.Contains(_tp))
                {
                    var videoPath = "\\Attachment\\video\\";
                    string AbsolutePath = HttpContext.Server.MapPath(videoPath);
                    if (!Directory.Exists(AbsolutePath))
                    {
                        Directory.CreateDirectory(AbsolutePath);
                    }
                    var lastImagePath = AbsolutePath + name;
                    fileContent.SaveAs(lastImagePath);
                    return JsonConvert.SerializeObject(new
                    {
                        code = 1,
                        msg = "上传成功",
                        data = new
                        {
                            src = videoPath + name,
                            title = ""
                        }
                    });
                }
            }
            return result;
        }
    }
}