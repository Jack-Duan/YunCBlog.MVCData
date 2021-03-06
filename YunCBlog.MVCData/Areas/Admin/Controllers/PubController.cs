﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YunCBlog.MVCData.Areas.Admin.Models.CommonViewModels;
using YunCBlog.MVCData.Areas.Admin.Models.PubViewModels;
using YunCBlog.MVCData.Filters;

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
        public ActionResult ModuleList(int id = 0)
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
            if (id > 0)
            {
                moduleList = moduleList.Where(e => e.ModuleId == id);
            }
            ViewBag.menu = "<a>首页</a><a><cite>模块管理</cite></a>";
            return View(moduleList);
        }
        #endregion

        #region 修改
        [HttpGet]
        public async Task<ActionResult> EditModule(int moduleId)
        {
            IBLL.IPubModuleListVistor moduleManager = new BLL.PubModuleListVistor();
            var model = await moduleManager.GetModel(moduleId).ConfigureAwait(false);
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
            IBLL.IPubModuleListVistor moduleManager = new BLL.PubModuleListVistor();
            List<SelectListItem> sliList = new List<SelectListItem>();
            foreach (var item in moduleManager.GetAllList())
            {
                sliList.Add(new SelectListItem
                {
                    Text = item.ModuleName,
                    Value = item.ModuleId.ToString()
                });
            }
            ViewBag.sliList = sliList;
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
                    DisOrder = model.DisOrder,
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
                DisOrder = model.DisOrder,
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
                    DisOrder = model.DisOrder,
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
        public ActionResult MenuList(CommonPagerViewModel pager)
        {
            IBLL.IPubMenuVistor menuManager = new BLL.PubMenuVistor();
            IBLL.IPubModuleListVistor moduleManager = new BLL.PubModuleListVistor();
            var menuList = menuManager.GetList(pager.page ?? 1, pager.size ?? 1);
            var moduleIds = menuList.Select(e => e.ModuleId).Distinct().ToList();
            var moduleModels = moduleManager.GetAllList().Where(e => moduleIds.Contains(e.ModuleId)).ToList();
            var retMenuList = menuManager.GetList(1, 10).Select(e => new PubMenuViewModel
            {
                ICon = e.ICon,
                ModuleName = moduleModels.Find(w => w.ModuleId == e.ModuleId)?.ModuleName,
                IsLeaf = e.IsLeaf,
                IsRemoved = e.IsRemoved,
                MenuName = e.MenuName,
                MenuUrlParam = e.MenuUrlParam,
                ModuleId = e.ModuleId,
                DisOrder = e.DisOrder,
                ParentMenuId = e.ParentMenuId,
                ParentMenuName = moduleModels.Find(w => w.ModuleId == e.ParentMenuId)?.ModuleName,
                MenuId = e.MenuId
            }).ToList();
            return View(retMenuList);
        }

        [HttpGet]
        public ActionResult CreateAccess()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccess(AccessListViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.IAccessListVistor accessManager = new BLL.AccessListVistor();
                var result = await accessManager.CreateModel(new Dto.AccessListDto
                {
                    AccessId = model.AccessId,
                    Browser = model.Browser,
                    DisOrder = model.DisOrder,
                    Http_Referer = model.Http_Referer,
                    IP = model.IP,
                    Local_Addr = model.Local_Addr,
                    IsRemoved = model.IsRemoved,
                    PageName = model.PageName,
                    MajorVersion = model.MajorVersion,
                    RealmName = model.RealmName,
                    Remote_Addr = model.Remote_Addr,
                    Remote_Host = model.Remote_Host,
                    Platform = model.Platform,
                    Server_Name = model.Server_Name,
                    Server_Port = model.Server_Port,
                    CreateTime = model.CreateTime,
                }).ConfigureAwait(false);
                if (result > 0)
                {
                    return RedirectToAction(nameof(MenuList));
                }
            }
            ModelState.AddModelError("", "添加失败！");
            return View();
        }

        [HttpGet]
        public ActionResult AccessList(CommonPagerViewModel pager)
        {
            IBLL.IAccessListVistor accessManager = new BLL.AccessListVistor();
            var models = accessManager.GetList(pager.page ?? 1, pager.size ?? 1).Select(e => new AccessListViewModel
            {
                AccessId = e.AccessId,
                Browser = e.Browser,
                DisOrder = e.DisOrder,
                Http_Referer = e.Http_Referer,
                IP = e.IP,
                Local_Addr = e.Local_Addr,
                IsRemoved = e.IsRemoved,
                PageName = e.PageName,
                MajorVersion = e.MajorVersion,
                RealmName = e.RealmName,
                Remote_Addr = e.Remote_Addr,
                Remote_Host = e.Remote_Host,
                Platform = e.Platform,
                Server_Name = e.Server_Name,
                Server_Port = e.Server_Port,
                CreateTime = e.CreateTime,
            }).ToList();
            return View(models);
        }


        #endregion

    }
}