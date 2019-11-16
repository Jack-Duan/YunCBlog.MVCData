using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YunCBlog.MVCData.Areas.Admin.Models.PubViewModels;

namespace YunCBlog.MVCData.Areas.Admin.Controllers
{
    public class PubController : Controller
    {
        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleList()
        {
            IBLL.IPubModuleListVistor moduleManager = new BLL.PubModuleListVistor();
            var moduleList = moduleManager.GetAllList();

            return View(moduleList);
        }
        [HttpGet]
        public ActionResult CreateModule()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateModule(PubModuleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IPubModuleListVistor moduleManager = new BLL.PubModuleListVistor();
                var result = await moduleManager.CreateModel(new Dto.PubModuleDto
                {
                    ModuleName = model?.ModuleName,
                    Memo = model.Memo,
                    ModuleCode = model.ModuleCode,
                    Url = model.Url
                }).ConfigureAwait(false);
                if (result > 0)
                {
                    return RedirectToAction(nameof(ModuleList));
                }
            }
            ModelState.AddModelError("", "添加失败！");
            return View(model);
        }
    }
}