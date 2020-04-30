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

namespace YunCBlog.BLL
{
    public class AccessListVistor : IAccessListVistor
    {
        public async Task<int> CreateModel(AccessListDto entity)
        {
            try
            {
                using (IDAL.IAccessListService moduleSvc = new DAL.AccessListService())
                {
                    return await moduleSvc.CreateAsync(new Models.AccessList
                    {
                        Browser = entity.Browser,
                        DisOrder = entity.DisOrder,
                        Http_Referer = entity.Http_Referer,
                        IP = entity.IP,
                        Local_Addr = entity.Local_Addr,
                        IsRemoved = entity.IsRemoved,
                        PageName = entity.PageName,
                        MajorVersion = entity.MajorVersion,
                        RealmName = entity.RealmName,
                        Remote_Addr = entity.Remote_Addr,
                        Remote_Host = entity.Remote_Host,
                        Platform = entity.Platform,
                        IpResult = entity.IpResult,
                        Address = entity.Address,
                        GuId = System.Guid.NewGuid(),
                        Server_Name = entity.Server_Name,
                        Server_Port = entity.Server_Port
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> EditModel(AccessListDto entity)
        {
            try
            {
                using (IDAL.IAccessListService moduleSvc = new DAL.AccessListService())
                {
                    return await moduleSvc.EditAsync(new Models.AccessList
                    {
                        AccessId = entity.AccessId,
                        Browser = entity.Browser,
                        DisOrder = entity.DisOrder,
                        Http_Referer = entity.Http_Referer,
                        IP = entity.IP,
                        GuId = entity.GuId,
                        Local_Addr = entity.Local_Addr,
                        IsRemoved = entity.IsRemoved,
                        PageName = entity.PageName,
                        MajorVersion = entity.MajorVersion,
                        RealmName = entity.RealmName,
                        Remote_Addr = entity.Remote_Addr,
                        Remote_Host = entity.Remote_Host,
                        Platform = entity.Platform,
                        Server_Name = entity.Server_Name,
                        Server_Port = entity.Server_Port
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AccessListDto> GetAllList()
        {
            try
            {
                using (IDAL.IAccessListService moduleSvc = new DAL.AccessListService())
                {
                    return moduleSvc.GetAll().Select(e => new AccessListDto
                    {
                        AccessId = e.AccessId,
                        Browser = e.Browser,
                        DisOrder = e.DisOrder,
                        Http_Referer = e.Http_Referer,
                        IP = e.IP,
                        Local_Addr = e.Local_Addr,
                        IsRemoved = e.IsRemoved,
                        PageName = e.PageName,
                        IpResult = e.IpResult,
                        Address = e.Address,
                        MajorVersion = e.MajorVersion,
                        RealmName = e.RealmName,
                        Remote_Addr = e.Remote_Addr,
                        Remote_Host = e.Remote_Host,
                        Platform = e.Platform,
                        Server_Name = e.Server_Name,
                        Server_Port = e.Server_Port,
                        CreateTime = e.CreateTime,
                        GuId = e.GuId
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AccessListDto> GetList(int page, int size)
        {
            try
            {
                using (IDAL.IAccessListService moduleSvc = new DAL.AccessListService())
                {
                    return moduleSvc.GetList(page, size).Select(e => new AccessListDto
                    {
                        AccessId = e.AccessId,
                        Browser = e.Browser,
                        DisOrder = e.DisOrder,
                        IpResult = e.IpResult,
                        Address = e.Address,
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
                        GuId = e.GuId
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AccessListDto> GetListByIds(List<int> ids)
        {
            try
            {
                using (IDAL.IAccessListService moduleSvc = new DAL.AccessListService())
                {
                    return moduleSvc.GetAll().Where(e => ids.Contains(e.AccessId)).Select(e => new AccessListDto
                    {
                        AccessId = e.AccessId,
                        Browser = e.Browser,
                        DisOrder = e.DisOrder,
                        IpResult = e.IpResult,
                        Address = e.Address,
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
                        GuId = e.GuId
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccessListDto> GetModel(int entityId)
        {
            try
            {
                using (IDAL.IAccessListService moduleSvc = new DAL.AccessListService())
                {
                    return await moduleSvc.GetAll().Where(e => e.AccessId == entityId).Select(e => new AccessListDto
                    {
                        AccessId = e.AccessId,
                        Browser = e.Browser,
                        DisOrder = e.DisOrder,
                        IpResult = e.IpResult,
                        Address = e.Address,
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
                        GuId = e.GuId
                    }).FirstAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// EditIp
        /// </summary>
        /// <returns></returns>
        public async Task<int> EditIp(int takeCount = 100)
        {
            using (IDAL.IAccessListService moduleSvc = new DAL.AccessListService())
            {
                var list = moduleSvc.GetAll().Where(e => string.IsNullOrEmpty(e.Address)).Take(takeCount).ToList();
                if (list != null && list.Count > 0)
                {
                    var ips = list.Select(e => e.IP).Distinct().ToList();
                    foreach (var item in ips)
                    {
                        try
                        {
                            var response = Get("https://m.so.com/position?ip=" + item);
                            var data = JsonConvert.DeserializeObject<IpResult>(response);
                            var thisIps = moduleSvc.GetAll().Where(e => e.IP == item && string.IsNullOrEmpty(e.Address)).ToList();
                            if (thisIps != null && thisIps.Count > 0)
                            {
                                foreach (var e in thisIps)
                                {
                                    await moduleSvc.EditAsync(new Models.AccessList
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
                                    }).ConfigureAwait(false);

                                }
                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }

                    }
                }

            }
            return 1;
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
    }
}
