using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YunCBlog.BLL;
using YunCBlog.MVCData.Areas.Admin.Models.ArticleViewModels;
using YunCBlog.MVCData.Models.ApplicationViewModels;

namespace YunCBlog.MVCData.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            IBLL.IBlogArticleListVistor blogManager = new BLL.BlogArticleListVistor();
            var models = blogManager.GetAllList().Where(e=>e.IsPublish==1).Take(15).Select(e => new ArticleViewModel
            {
                ArticleId = e.ArticleId,
                HtmlContent = e.HtmlContent,
                DisOrder = e.DisOrder,
                ArticleTypeLinkId = e.ArticleTypeLinkId,
                IsCanReprint = e.IsCanReprint,
                IsPrivate = e.IsPrivate,
                IsPublish = e.IsPublish,
                IsRemoved = e.IsRemoved,
                IsTop = e.IsTop,
                LikeCount = e.LikeCount,
                MarkDownContent = e.MarkDownContent,
                ReadCount = e.ReadCount,
                ReprintCount = e.ReprintCount,
                TextContent = e.TextContent,
                TipCount = e.TipCount,
                CreateTime = e.CreateTime,
                Title = e.Title,
                CoverName = e.CoverName,
                Theme = e.Theme,
                WordNumber = e.WordNumber
            }).ToList();
            return View(models);
        }
        /// <summary>
        /// header部分
        /// </summary>
        /// <returns></returns>
        public ActionResult _Header()
        {
            IBLL.IArticleModuleVistor articleManager = new BLL.ArticleModuleVistor();
            var result = new List<MenuViewModel>();
            IBLL.IArticleType_LinkVistor typeLinkManager = new BLL.ArticleType_LinkVistor();

            var articleList = articleManager.GetAllList();
            if (articleList != null && articleList.Count > 0)
            {
                foreach (var item in articleList.FindAll(e => e.ParentModuleId == 0))
                {
                    var childMenu = articleList.FindAll(e => e.ParentModuleId == item.ArticleModuleId).Select(e => new MenuViewModel
                    {
                        Url = e.Url,
                        MenuId = e.ArticleModuleId,
                        MenuName = e.ArticleModuleName
                    }).ToList();
                    result.Add(new MenuViewModel
                    {
                        MenuId = item.ArticleModuleId,
                        MenuName = item.ArticleModuleName,
                        Url = item.Url,
                        ChildMenuViewModel = childMenu
                    });
                }
            }
            return PartialView(result);
        }
        /// <summary>
        /// Banner
        /// </summary>
        /// <returns></returns>
        public ActionResult _Banner()
        {
            IBLL.IBlogArticleListVistor blogManager = new BLL.BlogArticleListVistor();
            List<ArticleViewModel> models = blogManager.GetAllList().Where(e => e.IsPublish == 1&&!string.IsNullOrEmpty(e.CoverName)).OrderByDescending(e=>e.DisOrder).Take(5).Select(e => new ArticleViewModel
            {
                ArticleId = e.ArticleId,
                HtmlContent = e.HtmlContent,
                DisOrder = e.DisOrder,
                ArticleTypeLinkId = e.ArticleTypeLinkId,
                IsCanReprint = e.IsCanReprint,
                IsPrivate = e.IsPrivate,
                IsPublish = e.IsPublish,
                IsRemoved = e.IsRemoved,
                IsTop = e.IsTop,
                LikeCount = e.LikeCount,
                MarkDownContent = e.MarkDownContent,
                ReadCount = e.ReadCount,
                ReprintCount = e.ReprintCount,
                TextContent = e.TextContent,
                TipCount = e.TipCount,
                CreateTime = e.CreateTime,
                Title = e.Title,
                CoverName = e.CoverName,
                Theme = e.Theme,
                WordNumber = e.WordNumber
            }).ToList();
            return PartialView(models);
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
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        //[ActionName("info")]
        [HttpGet]
        public async Task<ActionResult> Content(int id)
        {
            IBLL.IBlogArticleListVistor blogManager = new BLL.BlogArticleListVistor();
            var model = await blogManager.GetModel(id).ConfigureAwait(false);

            return View(new ArticleViewModel
            {
                HtmlContent = model.HtmlContent,
                DisOrder = model.DisOrder,
                ArticleTypeLinkId = model.ArticleTypeLinkId,
                IsCanReprint = model.IsCanReprint,
                IsPrivate = model.IsPrivate,
                IsPublish = model.IsPublish,
                IsRemoved = model.IsRemoved,
                IsTop = model.IsTop,
                LikeCount = model.LikeCount,
                MarkDownContent = model.MarkDownContent,
                ReadCount = model.ReadCount,
                ReprintCount = model.ReprintCount,
                TextContent = model.TextContent,
                TipCount = model.TipCount,
                CreateTime = model.CreateTime,
                Title = model.Title,
                Theme = model.Theme,
                WordNumber = model.WordNumber
            });
        }
    }
}