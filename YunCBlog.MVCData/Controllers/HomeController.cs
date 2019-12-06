﻿using System;
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
        public async Task<ActionResult> Content(int articleId)
        {
            IBLL.IBlogArticleListVistor blogManager = new BLL.BlogArticleListVistor();
            var model = await blogManager.GetModel(articleId).ConfigureAwait(false);

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
                CreateTime=model.CreateTime,
                Title = model.Title,
                Theme = model.Theme,
                WordNumber = model.WordNumber
            });
        }
    }
}