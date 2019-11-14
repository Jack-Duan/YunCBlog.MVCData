﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.DAL;
using YunCBlog.Dto;
using YunCBlog.IBLL;
using YunCBlog.IDAL;

namespace YunCBlog.BLL
{
    public class UserVistor : IUserVistor
    {
        public async Task<UserInfoDto> GetUserByEmail(string email)
        {
            using (IUserService userSvc = new UserService())
            {
                if (await userSvc.GetAll().AnyAsync(m => m.Email == email))
                {
                    return await userSvc.GetAll().Where(e => e.Email == email).Select(e => new Dto.UserInfoDto
                    {
                        Email = e.Email,
                        GuId = e.GuId,
                        SiteName = e.SiteName,
                        UserName = e.UserName
                    }).FirstAsync();
                }
                else
                {
                    throw new ArgumentException("邮箱地址不存在。");
                }
            }
        }

        public async Task<List<UserInfoDto>> GetUserList()
        {
            using (IUserService userSvc = new UserService())
            {
                return await userSvc.GetAll().Where(e => e.IsRemoved == false).Select(e => new Dto.UserInfoDto
                {
                    Email = e.Email,
                    GuId = e.GuId,
                    SiteName = e.SiteName,
                    UserName = e.UserName
                }).ToListAsync();
            }
        }
        /// <summary>
        /// 添加账户
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns></returns>
        public async Task<int> Register(UserInfoDto entity)
        {
            using (IUserService userSvc = new UserService())
            {
                return await userSvc.CreateAsync(new Models.User
                {
                    Email = entity.Email,
                    PassWord = entity.PassWord,
                    SiteName = entity.SiteName,
                    UserName = entity.UserName
                });
            }
        }

    }
}
