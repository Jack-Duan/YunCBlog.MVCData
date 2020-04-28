using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.Dto;
using YunCBlog.IBLL;
using YunCBlog.Models;

namespace YunCBlog.BLL
{
    public class BlogArticleListVistor : IBlogArticleListVistor
    {
        public async Task<int> CreateModel(BlogArticleListDto entity)
        {
            using (IDAL.IBlogArticleListService articleSvc = new DAL.BlogArticleListService())
            {
                return await articleSvc.CreateAsync(new Models.BlogArticleList
                {
                    ArticleTypeLinkId = entity.ArticleTypeLinkId ?? 0,
                    HtmlContent = entity.HtmlContent,
                    IsCanReprint = entity.IsCanReprint,
                    IsPrivate = entity.IsPrivate ?? 0,
                    IsPublish = entity.IsPublish ?? 0,
                    IsRemoved = entity.IsRemoved ?? 0,
                    IsTop = entity.IsTop ?? 0,
                    GuId = System.Guid.NewGuid(),
                    MarkDownContent = entity.MarkDownContent,
                    LikeCount = entity.LikeCount ?? 0,
                    ReadCount = entity.ReadCount ?? 0,
                    ReprintCount = entity.ReprintCount ?? 0,
                    TextContent = entity.TextContent,
                    TipCount = entity.TipCount ?? 0,
                    CoverName = entity.CoverName,
                    Title = entity.Title,
                    Theme = entity.Theme,
                    WordNumber = entity.WordNumber ?? 0,
                    ArticleModuleId = entity.ArticleModuleId
                });
            }
        }


        public async Task<int> EditModel(BlogArticleListDto entity)
        {
            using (IDAL.IBlogArticleListService articleSvc = new DAL.BlogArticleListService())
            {
                var model =await articleSvc.GetAll().Where(e => e.ArticleId == entity.ArticleId).FirstOrDefaultAsync();
                return await articleSvc.EditAsync(new Models.BlogArticleList
                {
                    ArticleTypeLinkId = entity.ArticleTypeLinkId,
                    HtmlContent = entity.HtmlContent,
                    IsCanReprint = entity.IsCanReprint,
                    IsPrivate = entity.IsPrivate,
                    IsPublish = entity.IsPublish,
                    IsRemoved = entity.IsRemoved,
                    IsTop = entity.IsTop,
                    MarkDownContent = entity.MarkDownContent,
                    LikeCount = entity.LikeCount,
                    ReadCount = entity.ReadCount,
                    ReprintCount = entity.ReprintCount,
                    TextContent = entity.TextContent,
                    TipCount = entity.TipCount,
                    CreateTime = model?.CreateTime ?? DateTime.Now,
                    Title = entity.Title,
                    CoverName = entity.CoverName,
                    Theme = entity.Theme,
                    DisOrder = entity.DisOrder,
                    WordNumber = entity.WordNumber,
                    ArticleModuleId = entity.ArticleModuleId,
                    ArticleId = entity.ArticleId
                });
            }
        }


        public void EditIp()
        {

            using (IDAL.IAccessListService moduleSvc = new DAL.AccessListService())
            {
                var list = moduleSvc.GetAll().Where(e => string.IsNullOrEmpty(e.Address)).Take(10).ToList();
                foreach (var e in list)
                {
                    try
                    {
                        var response = Get("https://m.so.com/position?ip=" + e.IP);
                        //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://m.so.com/position?ip="+e.IP);
                        //Encoding encoding = Encoding.UTF8;
                        ////byte[] bs = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new { ip = e.IP }));
                        //string responseData = String.Empty;
                        //req.Method = "GET";
                        //req.ContentType = "application/json";
                        //req.AutomaticDecompression = DecompressionMethods.GZip;
                        ////req.ContentLength = bs.Length;
                        ////using (Stream reqStream = req.GetRequestStream())
                        ////{
                        ////    reqStream.Write(bs, 0, bs.Length);
                        ////    reqStream.Close();
                        ////}
                        //using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                        //{
                        //    using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                        //    {
                        //        responseData = reader.ReadToEnd().ToString();
                        //    }
                        //}
                        var data = JsonConvert.DeserializeObject<IpResult>(response);
                        moduleSvc.EditAsync(new Models.AccessList
                        {
                            AccessId = e.AccessId,
                            Browser = e.Browser,
                            DisOrder = e.DisOrder,
                            Http_Referer = e.Http_Referer,
                            IP = e.IP,
                            Local_Addr = e.Local_Addr,
                            IsRemoved = e.IsRemoved,
                            PageName = e.PageName,
                            IpResult = response,
                            Address = data.data.position.country + "-" + data.data.position.province + "-" + data.data.position.city,
                            MajorVersion = e.MajorVersion,
                            RealmName = e.RealmName,
                            Remote_Addr = e.Remote_Addr,
                            Remote_Host = e.Remote_Host,
                            Platform = e.Platform,
                            Server_Name = e.Server_Name,
                            Server_Port = e.Server_Port,
                            CreateTime = e.CreateTime,
                        });


                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
        }
        public static string Get(string Url)
        {
            //System.GC.Collect();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }

            return retString;
        }
        private class data
        {
            public mso mso { get; set; }
            public string ip { get; set; }
            public position position { get; set; }
        }

        private class mso
        {
            public string x { get; set; }
            public string y { get; set; }
        }
        private class position
        {
            public string province { get; set; }
            public string isp { get; set; }
            public string adcode { get; set; }
            public string area { get; set; }
            public string address { get; set; }
            public string city { get; set; }
            public string city_code { get; set; }
            public string country { get; set; }
            public string street { get; set; }
            public string weathercode { get; set; }
        }

        private class IpResult
        {
            public data data { get; set; }
            public string message { get; set; }
        }


        public List<BlogArticleListDto> GetAllList()
        {
            using (IDAL.IBlogArticleListService articleSvc = new DAL.BlogArticleListService())
            {
                EditIp();
                return articleSvc.GetAll().Select(e => new BlogArticleListDto
                {
                    ArticleTypeLinkId = e.ArticleTypeLinkId,
                    HtmlContent = e.HtmlContent,
                    IsCanReprint = e.IsCanReprint,
                    IsPrivate = e.IsPrivate,
                    IsPublish = e.IsPublish,
                    IsRemoved = e.IsRemoved,
                    IsTop = e.IsTop,
                    MarkDownContent = e.MarkDownContent,
                    LikeCount = e.LikeCount,
                    ReadCount = e.ReadCount,
                    ReprintCount = e.ReprintCount,
                    TextContent = e.TextContent,
                    TipCount = e.TipCount,
                    Title = e.Title,
                    CoverName = e.CoverName,
                    Theme = e.Theme,
                    ArticleModuleId = e.ArticleModuleId,
                    DisOrder = e.DisOrder,
                    CreateTime = e.CreateTime,
                    WordNumber = e.WordNumber,
                    ArticleId = e.ArticleId
                }).ToList();
            }
        }

        public List<BlogArticleListDto> GetList(int page, int size)
        {
            using (IDAL.IBlogArticleListService articleSvc = new DAL.BlogArticleListService())
            {
                return articleSvc.GetList(page, size).Select(e => new BlogArticleListDto
                {
                    ArticleTypeLinkId = e.ArticleTypeLinkId,
                    HtmlContent = e.HtmlContent,
                    IsCanReprint = e.IsCanReprint,
                    IsPrivate = e.IsPrivate,
                    IsPublish = e.IsPublish,
                    IsRemoved = e.IsRemoved,
                    IsTop = e.IsTop,
                    Theme = e.Theme,
                    CoverName = e.CoverName,
                    MarkDownContent = e.MarkDownContent,
                    LikeCount = e.LikeCount,
                    ReadCount = e.ReadCount,
                    ReprintCount = e.ReprintCount,
                    TextContent = e.TextContent,
                    TipCount = e.TipCount,
                    ArticleModuleId = e.ArticleModuleId,
                    Title = e.Title,
                    DisOrder = e.DisOrder,
                    WordNumber = e.WordNumber,
                    CreateTime = e.CreateTime,
                    ArticleId = e.ArticleId
                }).ToList();
            }
        }
        public List<BlogArticleListDto> GetListByIds(List<int> ids)
        {
            using (IDAL.IBlogArticleListService articleSvc = new DAL.BlogArticleListService())
            {
                return articleSvc.GetAll().Where(e => ids.Contains((int)e.ArticleId)).Select(e => new BlogArticleListDto
                {
                    ArticleTypeLinkId = e.ArticleTypeLinkId,
                    HtmlContent = e.HtmlContent,
                    IsCanReprint = e.IsCanReprint,
                    IsPrivate = e.IsPrivate,
                    IsPublish = e.IsPublish,
                    IsRemoved = e.IsRemoved,
                    IsTop = e.IsTop,
                    Theme = e.Theme,
                    CoverName = e.CoverName,
                    MarkDownContent = e.MarkDownContent,
                    LikeCount = e.LikeCount,
                    ReadCount = e.ReadCount,
                    ReprintCount = e.ReprintCount,
                    ArticleModuleId = e.ArticleModuleId,
                    TextContent = e.TextContent,
                    TipCount = e.TipCount,
                    Title = e.Title,
                    DisOrder = e.DisOrder,
                    WordNumber = e.WordNumber,
                    CreateTime = e.CreateTime,
                    ArticleId = e.ArticleId
                }).ToList();
            }
        }

        public async Task<BlogArticleListDto> GetModel(int entityId)
        {
            using (IDAL.IBlogArticleListService articleSvc = new DAL.BlogArticleListService())
            {
                return await articleSvc.GetAll().Where(e => e.ArticleId == entityId).Select(e => new BlogArticleListDto
                {
                    ArticleTypeLinkId = e.ArticleTypeLinkId,
                    HtmlContent = e.HtmlContent,
                    IsCanReprint = e.IsCanReprint,
                    ArticleModuleId = e.ArticleModuleId,
                    IsPrivate = e.IsPrivate,
                    IsPublish = e.IsPublish,
                    IsRemoved = e.IsRemoved,
                    IsTop = e.IsTop,
                    CoverName = e.CoverName,
                    Theme = e.Theme,
                    MarkDownContent = e.MarkDownContent,
                    LikeCount = e.LikeCount,
                    ReadCount = e.ReadCount,
                    ReprintCount = e.ReprintCount,
                    TextContent = e.TextContent,
                    TipCount = e.TipCount,
                    Title = e.Title,
                    DisOrder = e.DisOrder,
                    WordNumber = e.WordNumber,
                    CreateTime = e.CreateTime,
                    ArticleId = e.ArticleId
                }).FirstAsync();
            }
        }
    }
}
