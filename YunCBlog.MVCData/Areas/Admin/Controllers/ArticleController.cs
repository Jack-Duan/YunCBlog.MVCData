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
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Dto.BlogArticleListDto model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IBlogArticleListVistor articleManager = new BLL.BlogArticleListVistor();
                var result = await articleManager.EditModel(model).ConfigureAwait(false);
                if (result > 0)
                {
                    return RedirectToAction(nameof(ArticleList));
                }
            }
            ModelState.AddModelError("", "修改失败！");
            return View();
        }


        [HttpGet]
        public ActionResult ArticleList()
        {
            IBLL.IBlogArticleListVistor articleManager = new BLL.BlogArticleListVistor();
            var models = articleManager.GetList(1, 20);
            return View(models);
        }

    }
}