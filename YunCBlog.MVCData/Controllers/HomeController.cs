using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YunCBlog.MVCData.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Header()
        {
            return PartialView();
        }
        public ActionResult _Banner()
        {
            return PartialView();
        }
        public ActionResult _Sidebar()
        {
            return PartialView();
        }
        public ActionResult _Footer()
        {
            return PartialView();
        }
    }
}