using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YunCBlog.MVCData.Areas.Admin.Models.ArticleViewModels;

namespace YunCBlog.MVCData.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IBlogArticleListVistor articleManager = new BLL.BlogArticleListVistor();
                var result = await articleManager.CreateModel(new Dto.BlogArticleListDto
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
                    Title = model.Title,
                    WordNumber = model.WordNumber
                }).ConfigureAwait(false);
                if (result > 0)
                {
                    return RedirectToAction(nameof(ArticleList));
                }
            }
            ModelState.AddModelError("", "添加失败！");
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int acticleid)
        {
            IBLL.IBlogArticleListVistor articleManager = new BLL.BlogArticleListVistor();
            var model = await articleManager.GetModel(acticleid).ConfigureAwait(false);
            return View(new ArticleViewModel
            {
                ArticleId = model.ArticleId,
                ArticleTypeLinkId = model.ArticleTypeLinkId,
                DisOrder = model.DisOrder,
                HtmlContent = model.HtmlContent,
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
                Title = model.Title,
                WordNumber = model.WordNumber
            });
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IBlogArticleListVistor articleManager = new BLL.BlogArticleListVistor();
                var result = await articleManager.EditModel(new Dto.BlogArticleListDto
                {
                    ArticleId = model.ArticleId,
                    ArticleTypeLinkId = model.ArticleTypeLinkId,
                    DisOrder = model.DisOrder,
                    HtmlContent = model.HtmlContent,
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
                    Title = model.Title,
                    WordNumber = model.WordNumber
                }).ConfigureAwait(false);
                if (result > 0)
                {
                    return RedirectToAction(nameof(ArticleList));
                }
            }
            ModelState.AddModelError("", "修改失败！");
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ArticModel(int id)
        {
            IBLL.IBlogArticleListVistor articleManager = new BLL.BlogArticleListVistor();
            var model = await articleManager.GetModel(id).ConfigureAwait(false);
            return View(new ArticleViewModel
            {
                HtmlContent = model.HtmlContent,
            });

        }


        [HttpGet]
        public ActionResult ArticleList()
        {
            IBLL.IBlogArticleListVistor articleManager = new BLL.BlogArticleListVistor();
            var models = articleManager.GetList(1, 20).Select(e => new ArticleViewModel
            {
                ArticleId = e.ArticleId,
                ArticleTypeLinkId = e.ArticleTypeLinkId,
                DisOrder = e.DisOrder,
                HtmlContent = e.HtmlContent,
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
                Title = e.Title,
                WordNumber = e.WordNumber
            });
            return View(models);
        }

        #region 文章模块管理
        [HttpGet]
        public ActionResult CreateArticleModule() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateArticleModule(ArticleModuleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IArticleModuleVistor articleModuleManager = new BLL.ArticleModuleVistor();
                var result = await articleModuleManager.CreateModel(new Dto.ArticleModuleDto
                {
                    ArticleModuleName = model.ArticleModuleName,
                    ArticleTypeId = model.ArticleTypeId,
                    ParentModuleId = model.ParentModuleId,
                    DisOrder = model.DisOrder,
                    IsRemoved = model.IsRemoved
                }).ConfigureAwait(false);
                if (result > 0)
                {
                    return RedirectToAction(nameof(ArticleModuleList));
                }
            }
            ModelState.AddModelError("", "添加失败");
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> EditArticleModule(int articleModuleId)
        {
            IBLL.IArticleModuleVistor articleModuleManager = new BLL.ArticleModuleVistor();
            var model =await articleModuleManager.GetModel(articleModuleId).ConfigureAwait(false);
            return View(new ArticleModuleViewModel
            {
                ArticleModuleId = model.ArticleModuleId,
                ArticleModuleName = model.ArticleModuleName,
                ArticleTypeId = model.ArticleTypeId,
                ParentModuleId = model.ParentModuleId,
                DisOrder = model.DisOrder,
                IsRemoved = model.IsRemoved
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditArticleModule(ArticleModuleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IArticleModuleVistor articleModuleManager = new BLL.ArticleModuleVistor();
                var result = await articleModuleManager.EditModel(new Dto.ArticleModuleDto
                {
                    ArticleModuleId = model.ArticleModuleId,
                    ArticleModuleName = model.ArticleModuleName,
                    ArticleTypeId = model.ArticleTypeId,
                    ParentModuleId = model.ParentModuleId,
                    DisOrder = model.DisOrder,
                    IsRemoved = model.IsRemoved
                }).ConfigureAwait(false);
                if (result > 0)
                {
                    return RedirectToAction(nameof(ArticleModuleList));
                }
            }
            ModelState.AddModelError("", "修改失败");
            return View(model);
        }
        [HttpGet]
        public ActionResult ArticleModuleList()
        {
            IBLL.IArticleModuleVistor articleModuleManager = new BLL.ArticleModuleVistor();
            var model = articleModuleManager.GetList(1, 10).Select(e => new ArticleModuleViewModel
            {
                ArticleModuleId = e.ArticleModuleId,
                ArticleModuleName = e.ArticleModuleName,
                ArticleTypeId = e.ArticleTypeId,
                ParentModuleId = e.ParentModuleId,
                DisOrder = e.DisOrder,
                CreateTime = e.CreateTime,
                IsRemoved = e.IsRemoved
            });
            return View(model);
        }
        #endregion


        #region 文章与模块关联管理
        [HttpGet]
        public ActionResult CreateArticleTypeLink() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateArticleTypeLink(ArticleTypeLinkViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IArticleType_LinkVistor articlelinkManager = new BLL.ArticleType_LinkVistor();
                var result = await articlelinkManager.CreateModel(new Dto.ArticleType_LinkDto
                {
                    ArticleId = model.ArticleId,
                    ArtcleModuleId = model.ArtcleModuleId,
                    DisOrder = model.DisOrder,
                    IsRemoved = model.IsRemoved,
                    IsUsed = model.IsUsed,
                    ParentArtcleModuleId = model.ParentArtcleModuleId
                }).ConfigureAwait(false);
                if (result > 0)
                {
                    return RedirectToAction(nameof(ArticleTypeLinkList));
                }
            }
            ModelState.AddModelError("", "添加失败");
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> EditArticleTypeLink(int articleTypeLinkId)
        {
            IBLL.IArticleType_LinkVistor articlelinkManager = new BLL.ArticleType_LinkVistor();
            var model = await articlelinkManager.GetModel(articleTypeLinkId).ConfigureAwait(false);
            return View(new ArticleTypeLinkViewModel
            {
                ArticleId = model.ArticleId,
                ArticleTypeLinkId = model.ArticleTypeLinkId,
                ArtcleModuleId = model.ArtcleModuleId,
                DisOrder = model.DisOrder,
                IsRemoved = model.IsRemoved,
                IsUsed = model.IsUsed,
                ParentArtcleModuleId = model.ParentArtcleModuleId,
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditArticleTypeLink(ArticleTypeLinkViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IArticleType_LinkVistor articlelinkManager = new BLL.ArticleType_LinkVistor();
                var result = await articlelinkManager.EditModel(new Dto.ArticleType_LinkDto
                {
                    ArticleId = model.ArticleId,
                    ArticleTypeLinkId = model.ArticleTypeLinkId,
                    ArtcleModuleId = model.ArtcleModuleId,
                    DisOrder = model.DisOrder,
                    IsRemoved = model.IsRemoved,
                    IsUsed = model.IsUsed,
                    ParentArtcleModuleId = model.ParentArtcleModuleId
                }).ConfigureAwait(false);
                if (result > 0)
                {
                    return RedirectToAction(nameof(ArticleTypeLinkList));
                }
            }
            ModelState.AddModelError("", "修改失败");
            return View(model);
        }
        [HttpGet]
        public ActionResult ArticleTypeLinkList()
        {
            IBLL.IArticleType_LinkVistor articlelinkManager = new BLL.ArticleType_LinkVistor();
            var model = articlelinkManager.GetList(1, 10).Select(e => new ArticleTypeLinkViewModel
            {
                ArticleTypeLinkId = e.ArticleTypeLinkId,
                ArticleId = e.ArticleId,
                ArtcleModuleId = e.ArtcleModuleId,
                DisOrder = e.DisOrder,
                IsRemoved = e.IsRemoved,
                IsUsed = e.IsUsed,
                ParentArtcleModuleId = e.ParentArtcleModuleId
            });
            return View(model);
        }

        #endregion


    }
}