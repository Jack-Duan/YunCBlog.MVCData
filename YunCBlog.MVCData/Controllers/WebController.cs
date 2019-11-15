using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YunCBlog.MVCData.Controllers
{
    public class WebController : Controller
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateUserAsync()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> CreateUserAsync(Models.UserViewModels.UserCreateInfo model)
        {
            if (!ModelState.IsValid) return View(model);
            IBLL.IUserVistor userManager = new BLL.UserVistor();
            var result = await userManager.Register(new Dto.UserInfoDto
            {
                Email = model.Email,
                PassWord = model.PassWord,
                SiteName = model.SiteName,
                UserName = model.UserName
            });
            if (result > 0)
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "您录入的信息有误");
            return View();
        }
    }
}