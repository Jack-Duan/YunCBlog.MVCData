using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.Dto;

namespace YunCBlog.IBLL
{
    public interface IUserVistor
    {
        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns></returns>
        Task<int> Register(Dto.UserInfoDto entity);
        /// <summary>
        /// 根据邮箱获取用户信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Dto.UserInfoDto> GetUserByEmail(string email);
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        Task<List<Dto.UserInfoDto>> GetUserList();
        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<int> Login(UserInfoDto entity);
    }
}
