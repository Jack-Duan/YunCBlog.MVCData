using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YunCBlog.MVCData.Areas.Admin.Views.AttachMent
{
    public class AttachMentController : Controller
    {
        // GET: Admin/AttachMent
        public ActionResult List()
        {


            return View();
        }

        public ActionResult Upload()
        {
            return Json("");
        }

    }
}