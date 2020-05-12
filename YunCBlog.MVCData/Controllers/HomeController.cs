using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YunCBlog.BLL;
using YunCBlog.MVCData.Areas.Admin.Models.ArticleViewModels;
using YunCBlog.MVCData.Filters;
using YunCBlog.MVCData.Models.ApplicationViewModels;

namespace YunCBlog.MVCData.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// 喜欢文章
        /// </summary>
        /// <param name="id">文章ID</param>
        [HttpGet]
        public async Task<int> SetLike(int id)
        {
            IBLL.IBlogArticleListVistor blogManager = new BLL.BlogArticleListVistor();
            var model = await blogManager.GetModel(id).ConfigureAwait(false);
            if (model != null)
            {
                return await blogManager.EditModel(new Dto.BlogArticleListDto
                {
                    ArticleId = id,
                    HtmlContent = WebUtility.UrlDecode(model.HtmlContent),
                    DisOrder = model.DisOrder,
                    ArticleTypeLinkId = model.ArticleTypeLinkId,
                    IsCanReprint = model.IsCanReprint,
                    IsPrivate = model.IsPrivate,
                    ArticleModuleId = model.ArticleModuleId,
                    IsPublish = model.IsPublish,
                    IsRemoved = model.IsRemoved,
                    IsTop = model.IsTop,
                    MarkDownContent = model.MarkDownContent,
                    ReadCount = model.ReadCount,
                    ReprintCount = model.ReprintCount,
                    TextContent = WebUtility.UrlDecode(model.TextContent),
                    TipCount = model.TipCount,
                    CreateTime = model.CreateTime,
                    Title = model.Title,
                    CoverName = model.CoverName,
                    Theme = model.Theme,
                    WordNumber = model.WordNumber,
                    LikeCount = model.LikeCount += 1
                }).ConfigureAwait(false);
            }
            return 0;
        }


        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet, AccessLog]
        public  ActionResult Index()
        {
            IBLL.IBlogArticleListVistor blogManager = new BLL.BlogArticleListVistor();
            var modelList = blogManager.GetAllList().Where(e => e.IsPublish == 1).Take(15);
            var moduleIds = modelList.Select(e => (int)e.ArticleModuleId)?.ToList();
            IBLL.IArticleModuleVistor moduleManager = new ArticleModuleVistor();
            var moduleList = moduleIds.Count > 0 ? moduleManager.GetListByIds(moduleIds) : new List<Dto.ArticleModuleDto>();
            if (HttpContext.Request.IsLocal)
            {
                IBLL.IAccessListVistor accesssManager = new BLL.AccessListVistor();
                accesssManager.EditIp();
            }
            var indexModule =  moduleManager.GetListByIds(new List<int> { 1 });
            ViewBag.KeyWords = indexModule.FirstOrDefault()?.KeyWords;
            ViewBag.Description = indexModule.FirstOrDefault()?.Description;
            var models = modelList.Select(e => new ArticleViewModel
            {
                ArticleId = e.ArticleId,
                HtmlContent = WebUtility.UrlDecode(e.HtmlContent),
                DisOrder = e.DisOrder,
                ArticleTypeLinkId = e.ArticleTypeLinkId,
                IsCanReprint = e.IsCanReprint,
                IsPrivate = e.IsPrivate,
                ArticleModuleId = e.ArticleModuleId,
                ArticleModuleUrl = moduleList.Find(w => e.ArticleModuleId == w.ArticleModuleId)?.Url,
                ArticleModuleName = moduleList.Find(w => e.ArticleModuleId == w.ArticleModuleId)?.ArticleModuleName,
                IsPublish = e.IsPublish,
                IsRemoved = e.IsRemoved,
                IsTop = e.IsTop,
                LikeCount = e.LikeCount,
                MarkDownContent = e.MarkDownContent,
                ReadCount = e.ReadCount,
                ReprintCount = e.ReprintCount,
                TextContent = WebUtility.UrlDecode(e.TextContent),
                TipCount = e.TipCount,
                CreateTime = e.CreateTime,
                Title = e.Title,
                CoverName = e.CoverName,
                Theme = e.Theme,
                WordNumber = e.WordNumber
            }).OrderByDescending(e => e.CreateTime).ToList();
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
                //    ViewBag.Description = articleList.Find(w => e.ArticleModuleId == w.ArticleModuleId)?.Description;
                //    ViewBag.KeyWords = "梦中的aoede,个人博客,博客模板,c#,";
                foreach (var item in articleList.FindAll(e => e.ParentModuleId == 0).OrderByDescending(e => e.DisOrder))
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
        public async Task<ActionResult> _Banner()
        {
            IBLL.IBlogArticleListVistor blogManager = new BLL.BlogArticleListVistor();
            var modelList = blogManager.GetAllList().Where(e => e.IsPublish == 1 && !string.IsNullOrEmpty(e.CoverName)).OrderByDescending(e => e.CreateTime).Take(5);
            var moduleIds = modelList.Select(e => (int)e.ArticleModuleId)?.ToList();
            IBLL.IArticleModuleVistor moduleManager = new ArticleModuleVistor();
            var moduleList = moduleIds.Count > 0 ? moduleManager.GetListByIds(moduleIds) : new List<Dto.ArticleModuleDto>();

            List<ArticleViewModel> models = modelList.Select(e => new ArticleViewModel
            {
                ArticleId = e.ArticleId,
                HtmlContent = WebUtility.UrlDecode(e.HtmlContent),
                DisOrder = e.DisOrder,
                ArticleTypeLinkId = e.ArticleTypeLinkId,
                ArticleModuleId = e.ArticleModuleId,
                ArticleModuleUrl = moduleList.Find(w => e.ArticleModuleId == w.ArticleModuleId)?.Url,
                ArticleModuleName = moduleList.Find(w => e.ArticleModuleId == w.ArticleModuleId)?.ArticleModuleName,
                IsCanReprint = e.IsCanReprint,
                IsPrivate = e.IsPrivate,
                IsPublish = e.IsPublish,
                IsRemoved = e.IsRemoved,
                IsTop = e.IsTop,
                LikeCount = e.LikeCount,
                MarkDownContent = e.MarkDownContent,
                ReadCount = e.ReadCount,
                ReprintCount = e.ReprintCount,
                TextContent = WebUtility.UrlDecode(e.TextContent),
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
        /// 创建评论
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> CreateComment(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                IBLL.ICommentListVistor CommentManager = new BLL.CommentListVistor();
                var ip = HttpContext.Request.ServerVariables["Remote_Host"];
                var result = await CommentManager.CreateModel(new Dto.CommentListDto
                {
                    UserId = 0,// model.UserId,
                    Content = model.Content,
                    DisOrder = 100,// model.DisOrder,
                    ImgUrl = "",//model.ImgUrl,
                    UserName = "游客" + ip.Split('.')?.Last(),
                    IP = HttpContext.Request.ServerVariables["Remote_Host"],
                    IsRemoved = 0,// model.IsRemoved,
                    LikeCount = model.LikeCount ?? 0,
                    ArticleId = model.ArticleId,
                    ParentCommentId = model.ParentCommentId ?? 0,
                    CreateTime = DateTime.Now
                }).ConfigureAwait(false);
                return result;
            }
            return 0;
        }

        [HttpGet]
        public JsonResult GetCommentList(int articleId)
        {
            IBLL.ICommentListVistor commentManager = new BLL.CommentListVistor();
            var models = commentManager.GetAllList().Where(e => e.ArticleId == articleId && e.IsRemoved == 0).OrderBy(e => e.CommentId).Select(model => new CommentViewModel
            {
                UserId = model.UserId,
                Content = model.Content,
                DisOrder = model.DisOrder,
                ImgUrl = model.ImgUrl,
                IP = model.IP,
                UserName = model.UserName,
                IsRemoved = model.IsRemoved,
                LikeCount = model.LikeCount,
                ParentCommentId = model.ParentCommentId,
                CommentId = model.CommentId,
                ArticleId = model.ArticleId,
                CreateTime = string.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd HH:mm:ss}", model.CreateTime)
            });
            var result = new JsonResult()
            {
                Data = models.ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;
        }

        [HttpGet]
        public async Task<JsonResult> SetCommentLike(int id)
        {

            IBLL.ICommentListVistor commentManager = new BLL.CommentListVistor();
            var model = await commentManager.GetModel(id).ConfigureAwait(false);
            var result = 0;
            if (model != null)
            {
                await commentManager.EditModel(new Dto.CommentListDto
                {
                    UserId = model.UserId,
                    Content = model.Content,
                    DisOrder = model.DisOrder,
                    ImgUrl = model.ImgUrl,
                    IP = model.IP,
                    UserName = model.UserName,
                    IsRemoved = model.IsRemoved,
                    LikeCount = model.LikeCount + 1,
                    ParentCommentId = model.ParentCommentId,
                    CommentId = model.CommentId,
                    ArticleId = model.ArticleId,
                    CreateTime = model.CreateTime
                }).ConfigureAwait(false);
                result = Convert.ToInt32(model.LikeCount) + 1;
            }
            return new JsonResult()
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        [HttpGet]
        public ActionResult Comment(int articleId)
        {
            IBLL.ICommentListVistor commentManager = new BLL.CommentListVistor();
            var models = commentManager.GetAllList().Where(e => e.ArticleId == articleId && e.IsRemoved == 0).OrderBy(e => e.CommentId).Select(model => new CommentViewModel
            {
                UserId = model.UserId,
                Content = model.Content,
                DisOrder = model.DisOrder,
                ImgUrl = model.ImgUrl,
                IP = model.IP,
                ArticleId = model.ArticleId,
                UserName = model.UserName,
                IsRemoved = model.IsRemoved,
                LikeCount = model.LikeCount,
                ParentCommentId = model.ParentCommentId,
                CommentId = model.CommentId,
                CreateTime = string.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd HH:mm:ss}", model.CreateTime)
            });
            ViewBag.ArticleId = articleId;
            return PartialView(models);
        }


        /// <summary>
        /// 通用侧边栏
        /// </summary>
        /// <returns></returns>
        public ActionResult _Sidebar()
        {
            IBLL.IBlogArticleListVistor blogManager = new BLL.BlogArticleListVistor();
            var modelList = blogManager.GetAllList().Where(e => e.IsPublish == 1 && !string.IsNullOrEmpty(e.CoverName)).OrderByDescending(e => e.DisOrder).Take(3);
            var moduleIds = modelList.Select(e => (int)e.ArticleModuleId)?.ToList();
            IBLL.IArticleModuleVistor moduleManager = new ArticleModuleVistor();
            var moduleList = moduleIds.Count > 0 ? moduleManager.GetListByIds(moduleIds) : new List<Dto.ArticleModuleDto>();
            var modules = moduleManager.GetList(1, 8);
            //item1:module主键 item2:名称 item3:url
            var moduleViews = modules?.Select(e => { return new Tuple<int, string, string>((int)e.ArticleModuleId, e.ArticleModuleName, e.Url); }).ToList();
            ViewData["modules"] = moduleViews;
            List<ArticleViewModel> models = modelList.Select(e => new ArticleViewModel
            {
                ArticleId = e.ArticleId,
                Title = e.Title,
                ArticleModuleUrl = moduleList.Find(w => e.ArticleModuleId == w.ArticleModuleId)?.Url,
                CoverName = e.CoverName,
            }).ToList();
            return PartialView(models);
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
        [HttpGet, AccessLog]
        public async Task<ActionResult> Content(int id)
        {
            IBLL.IBlogArticleListVistor blogManager = new BLL.BlogArticleListVistor();


            var model = await blogManager.GetModel(id).ConfigureAwait(false);
            model.CreateTime = model.CreateTime;
            model.ReadCount = model.ReadCount + 1;
            await blogManager.EditModel(model).ConfigureAwait(false);
            var moduleIds = new List<int>() { (int)model.ArticleModuleId };
            IBLL.IArticleModuleVistor moduleManager = new ArticleModuleVistor();
            var moduleList = moduleIds.Count > 0 ? moduleManager.GetListByIds(moduleIds) : new List<Dto.ArticleModuleDto>();

            var articleList = blogManager.GetAllList().Where(e => e.ArticleModuleId == model.ArticleModuleId).ToList();
            var prevModel = articleList.Where(e => e.ArticleId < model.ArticleId).OrderByDescending(e => e.ArticleId).FirstOrDefault();
            var nextModel = articleList.Where(e => e.ArticleId > model.ArticleId).OrderBy(e => e.ArticleId).FirstOrDefault();


            return View(new ArticleViewModel
            {
                ArticleId = model.ArticleId,
                HtmlContent = WebUtility.UrlDecode(model.HtmlContent),
                DisOrder = model.DisOrder,
                ArticleTypeLinkId = model.ArticleTypeLinkId,
                IsCanReprint = model.IsCanReprint,
                IsPrivate = model.IsPrivate,
                IsPublish = model.IsPublish,
                IsRemoved = model.IsRemoved,
                IsTop = model.IsTop,
                ArticleModuleUrl = moduleList.Find(w => model.ArticleModuleId == w.ArticleModuleId)?.Url,
                ArticleModuleName = moduleList.Find(w => model.ArticleModuleId == w.ArticleModuleId)?.ArticleModuleName,
                LikeCount = model.LikeCount,
                MarkDownContent = model.MarkDownContent,
                ReadCount = model.ReadCount,
                ReprintCount = model.ReprintCount,
                TextContent = WebUtility.UrlDecode(model.TextContent),
                TipCount = model.TipCount,
                CreateTime = model.CreateTime,
                Title = model.Title,
                Theme = model.Theme,
                PrevArticleId = prevModel?.ArticleId,
                PrevArticleTitle = prevModel?.Title,
                NextArticleId = nextModel?.ArticleId,
                NextArticleTitle = nextModel?.Title,
                WordNumber = model.WordNumber
            });
        }

        [HttpGet, AccessLog]
        public ActionResult List(int id)
        {
            IBLL.IBlogArticleListVistor blogManager = new BLL.BlogArticleListVistor();
            var modelList = blogManager.GetAllList().Where(e => e.ArticleModuleId == id).Take(15);
            IBLL.IArticleModuleVistor moduleManager = new ArticleModuleVistor();
            var moduleIds = modelList.Select(e => (int)e.ArticleModuleId).ToList();
            var moduleList = moduleIds.Count > 0 ? moduleManager.GetListByIds(new List<int> { id }) : new List<Dto.ArticleModuleDto>();
            var articleModuleName = "";
            if (moduleList != null && moduleList.Count > 0)
            {
                articleModuleName = moduleList.First().ArticleModuleName;
                ViewBag.KeyWords = moduleList.First().KeyWords;
                ViewBag.Description = moduleList.First().Description;
            }


            List<YunCBlog.MVCData.Areas.Admin.Models.ArticleViewModels.ArticleViewModel> models = modelList.Select(e => new ArticleViewModel
            {
                ArticleId = e.ArticleId,
                HtmlContent = WebUtility.UrlDecode(e.HtmlContent),
                DisOrder = e.DisOrder,
                ArticleTypeLinkId = e.ArticleTypeLinkId,
                IsCanReprint = e.IsCanReprint,
                IsPrivate = e.IsPrivate,
                ArticleModuleId = e.ArticleModuleId,
                ArticleModuleName = articleModuleName,
                IsPublish = e.IsPublish,
                IsRemoved = e.IsRemoved,
                IsTop = e.IsTop,
                LikeCount = e.LikeCount,
                MarkDownContent = e.MarkDownContent,
                ReadCount = e.ReadCount,
                ReprintCount = e.ReprintCount,
                TextContent = WebUtility.UrlDecode(e.TextContent),
                TipCount = e.TipCount,
                CreateTime = e.CreateTime,
                Title = e.Title,
                CoverName = e.CoverName,
                Theme = e.Theme,
                WordNumber = e.WordNumber
            }).OrderByDescending(e => e.DisOrder).ToList();
            ViewBag.articleModuleName = articleModuleName;
            return View(models);

        }


    }
}