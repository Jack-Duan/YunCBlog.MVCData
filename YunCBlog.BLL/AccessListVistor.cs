using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                    GuId = System.Guid.NewGuid(),
                    Server_Name = entity.Server_Name,
                    Server_Port = entity.Server_Port
                });
            }
        }

        public async Task<int> EditModel(AccessListDto entity)
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

        public List<AccessListDto> GetAllList()
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

        public List<AccessListDto> GetList(int page, int size)
        {
            using (IDAL.IAccessListService moduleSvc = new DAL.AccessListService())
            {
                return moduleSvc.GetList(page, size).Select(e => new AccessListDto
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
                    GuId = e.GuId
                }).ToList();
            }
        }

        public List<AccessListDto> GetListByIds(List<int> ids)
        {
            using (IDAL.IAccessListService moduleSvc = new DAL.AccessListService())
            {
                return moduleSvc.GetAll().Where(e => ids.Contains(e.AccessId)).Select(e => new AccessListDto
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
                    GuId = e.GuId
                }).ToList();
            }
        }

        public async Task<AccessListDto> GetModel(int entityId)
        {
            using (IDAL.IAccessListService moduleSvc = new DAL.AccessListService())
            {
                return await moduleSvc.GetAll().Where(e => e.AccessId == entityId).Select(e => new AccessListDto
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
                    GuId = e.GuId
                }).FirstAsync();
            }
        }
    }
}
