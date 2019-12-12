using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YunCBlog.MVCData.Areas.Admin.Models.AttachMentViewModels;

namespace YunCBlog.MVCData.Areas.Admin.Controllers
{
    public class AttachMentController : Controller
    {
        private string imagePath = "/AttachMent/Image/";
        private string videoPath = "/AttachMent/Vedio/";
        // GET: Admin/AttachMent
        [HttpGet]
        public ActionResult List()
        {
            return View(GetFileList(1, 10));
        }

        private List<AttachMentViewModel> GetFileList(int page, int size)
        {
            var result = new List<AttachMentViewModel>();
            DirectoryInfo root = new DirectoryInfo(Server.MapPath(imagePath));
            var files = root.GetFiles();
            foreach (var item in files)
            {
                result.Add(new AttachMentViewModel
                {
                    AttachMentName = item.Name,
                    AttacheMentUrl = imagePath + item.Name
                });
            }
            return result;
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
                var imagesExtensions = new List<string> { ".jpg", ".jpeg", ".gif", ".png", ".swf" };
                var videoExtensions = new List<string> { ".mp4", ".flv", ".avi", ".rm", ".rmvb" };
                if (imagesExtensions.Contains(_tp))
                {
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
                            src = GetFilePath(name),
                            title = ""
                        }
                    });
                }
                else if (videoExtensions.Contains(_tp))
                {
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
                            src = GetFilePath(name),
                            title = ""
                        }
                    });
                }
            }
            return result;
        }

        public string GetFilePath(string fileName)
        {
            return imagePath + fileName;
        }
        [HttpGet]
        public ActionResult GetFile(string fileName)
        {
            return File(GetFilePath(fileName), "image/jpeg");
        }
    }
}