using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Dto.BlogArticleListDto model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IBlogArticleListVistor articleManager = new BLL.BlogArticleListVistor();
                var result = await articleManager.CreateModel(model).ConfigureAwait(false);
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