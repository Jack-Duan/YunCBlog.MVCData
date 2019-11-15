using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YunCBlog.MVCData.Areas.Admin.Models.UserViewModels;

namespace YunCBlog.MVCData.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// 创建用户页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IUserVistor UserManager = new BLL.UserVistor();
                var result = await UserManager.Register(new Dto.UserInfoDto
                {
                    UserName = model?.UserName,
                    Email = model.Email,
                    PassWord = model.PassWord,
                    SiteName = model.SiteName
                }).ConfigureAwait(false);
                return RedirectToAction(nameof(UserLogin));
            }
            return View(model);
        }

        /// <summary>
        /// 用户登录页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserLogin(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IUserVistor UserManager = new BLL.UserVistor();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        /// <summary>
        /// 管理首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}