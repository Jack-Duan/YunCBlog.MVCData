using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using YunCBlog.MVCData.Areas.Admin.Models.PubViewModels;
using YunCBlog.MVCData.Areas.Admin.Models.UserViewModels;
using YunCBlog.MVCData.Filters;

namespace YunCBlog.MVCData.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// 创建用户页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AccessLog]
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
        [AccessLog]
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
                var ret = await UserManager.Login(new Dto.UserInfoDto
                {
                    Email = model?.UserName,
                    UserName = model.UserName,
                    PassWord = model.PassWord
                }).ConfigureAwait(false);
                if (ret > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "登录失败！账号或密码错误！");
                }
            }
            return View(model);
        }
        /// <summary>
        /// 管理首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AccessLog]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 左侧菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult _LeftMenu()
        {
            List<ShowMenuViewModel> menuList = new List<ShowMenuViewModel>();
            IBLL.IPubMenuVistor menuManager = new BLL.PubMenuVistor();
            var menu = menuManager.GetAllList().OrderByDescending(e => e.DisOrder);
            IBLL.IPubModuleListVistor moduleManager = new BLL.PubModuleListVistor();
            var module = moduleManager.GetAllList();
            foreach (var item in menu)
            {
                var itemModule = module.Find(e => e.ModuleId == item.ModuleId);
                menuList.Add(new ShowMenuViewModel
                {
                    ICon = item.ICon,
                    IsLeaf = item.IsLeaf,
                    MenuId = item.MenuId,
                    MenuName = item.MenuName,
                    MenuUrlParam = item.MenuUrlParam,
                    ParentMenuId = item.ParentMenuId,
                    Url = module.Find(e => e.ModuleId == item.ModuleId)?.Url
                });

            }

            return PartialView(menuList);
        }
    }
}