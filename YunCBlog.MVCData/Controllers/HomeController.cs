using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YunCBlog.BLL;

namespace YunCBlog.MVCData.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// header部分
        /// </summary>
        /// <returns></returns>
        public ActionResult _Header()
        {
            return PartialView();
        }
        /// <summary>
        /// Banner
        /// </summary>
        /// <returns></returns>
        public ActionResult _Banner()
        {
            return PartialView();
        }
        /// <summary>
        /// 通用侧边栏
        /// </summary>
        /// <returns></returns>
        public ActionResult _Sidebar()
        {
            return PartialView();
        }
        /// <summary>
        /// foot页脚
        /// </summary>
        /// <returns></returns>
        public ActionResult _Footer()
        {
            return PartialView();
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Test(Models.UserViewModels.UserCreateInfo model)
        {
            if (!ModelState.IsValid) return View(model);

            IBLL.IUserVistor userManager = new  UserVistor();
            var result = await userManager.Register(new Dto.UserInfoDto
            {
                Email = model.Email,
                PassWord = model.PassWord,
                SiteName = model.SiteName,
                UserName = model.UserName
            });
            return Content("成功");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateUser(Models.UserViewModels.UserCreateInfo model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IUserVistor userManager = new UserVistor();
                var result = userManager.Register(new Dto.UserInfoDto
                {
                    Email = model.Email,
                    PassWord = model.PassWord,
                    SiteName = model.SiteName,
                    UserName = model.UserName
                });
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "您录入的信息有误");
            return View(model);
        }
    }
}