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
        #region 模块管理
        #region 创建
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
        #endregion
        #region 查询
        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModuleList()
        {
            IBLL.IPubModuleListVistor moduleManager = new BLL.PubModuleListVistor();
            var moduleList = moduleManager.GetAllList().Select(e => new PubModuleViewModel
            {
                ModuleName = e?.ModuleName,
                Memo = e.Memo,
                ModuleCode = e.ModuleCode,
                Url = e.Url,
                IsRemoved = e.IsRemoved,
                ModuleId = e.ModuleId
            });
            return View(moduleList);
        }
        #endregion

        #region 修改
        [HttpGet]
        public async Task<ActionResult> EditModule(int moduleId)
        {
            IBLL.IPubModuleListVistor moduleManager =new BLL.PubModuleListVistor();
            var model =await moduleManager.GetModel(moduleId).ConfigureAwait(false);
            return View(new PubModuleViewModel
            {
                ModuleId = model.ModuleId,
                IsRemoved = model.IsRemoved,
                Memo = model.Memo,
                ModuleCode = model.ModuleCode,
                ModuleName = model.ModuleName,
                Url = model.Url
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditModule(PubModuleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IPubModuleListVistor moduleBll = new BLL.PubModuleListVistor();
                var result = await moduleBll.EditModel(new Dto.PubModuleDto
                {
                    ModuleId = model.ModuleId,
                    IsRemoved = model.IsRemoved,
                    Memo = model.Memo,
                    ModuleCode = model.ModuleCode,
                    ModuleName = model.ModuleName,
                    Url = model.Url
                }).ConfigureAwait(false);
                if (result > 0)
                {
                    return RedirectToAction(nameof(ModuleList));
                }
            }
            ModelState.AddModelError("", "修改失败！");
            return View(model);
        }
        #endregion

        #endregion


        #region 菜单管理
        [HttpGet]
        public ActionResult CreateMenu()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateMenu(PubMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IPubMenuVistor menuBll = new BLL.PubMenuVistor();
                var result = await menuBll.CreateModel(new Dto.PubMenuDto
                {
                    ICon = model.ICon,
                    IsLeaf = model.IsLeaf,
                    IsRemoved = model.IsRemoved,
                    MenuName = model.MenuName,
                    MenuUrlParam = model.MenuUrlParam,
                    ModuleId = model.ModuleId,
                    ParentMenuId = model.ParentMenuId
                }).ConfigureAwait(false);
                if (result > 0)
                {
                    return RedirectToAction(nameof(MenuList));
                }
            }
            ModelState.AddModelError("", "添加失败！");
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> EditMenu(int menuid)
        {
            IBLL.IPubMenuVistor menuBll = new BLL.PubMenuVistor();
            var model = await menuBll.GetModel(menuid).ConfigureAwait(false); 
            return View(new PubMenuViewModel
            {
                MenuId = model.MenuId,
                ICon = model.ICon,
                IsLeaf = model.IsLeaf,
                IsRemoved = model.IsRemoved,
                MenuName = model.MenuName,
                MenuUrlParam = model.MenuUrlParam,
                ModuleId = model.ModuleId,
                ParentMenuId = model.ParentMenuId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditMenu(PubMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IPubMenuVistor menuBll = new BLL.PubMenuVistor();
                var result = await menuBll.EditModel(new Dto.PubMenuDto
                {
                    MenuId = model.MenuId,
                    ICon = model.ICon,
                    IsLeaf = model.IsLeaf,
                    IsRemoved = model.IsRemoved,
                    MenuName = model.MenuName,
                    MenuUrlParam = model.MenuUrlParam,
                    ModuleId = model.ModuleId,
                    ParentMenuId = model.ParentMenuId
                }).ConfigureAwait(false);
                if (result > 0)
                {
                    return RedirectToAction(nameof(MenuList));
                }
            }
            ModelState.AddModelError("", "修改失败！");
            return View(model);
        }



        [HttpGet]
        public ActionResult MenuList()
        {
            IBLL.IPubMenuVistor menuManager = new BLL.PubMenuVistor();
            var menuList = menuManager.GetList(1, 10).Select(e => new PubMenuViewModel
            {
                ICon = e.ICon,
                IsLeaf = e.IsLeaf,
                IsRemoved = e.IsRemoved,
                MenuName = e.MenuName,
                MenuUrlParam = e.MenuUrlParam,
                ModuleId = e.ModuleId,
                ParentMenuId = e.ParentMenuId,
                MenuId = e.MenuId
            }).ToList();
            return View(menuList);
        }




        #endregion

    }
}