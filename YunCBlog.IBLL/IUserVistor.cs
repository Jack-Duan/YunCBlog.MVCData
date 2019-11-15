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
        Task<int> Register(Dto.UserInfoDto entity);
        Task<Dto.UserInfoDto> GetUserByEmail(string email);
        Task<List<Dto.UserInfoDto>> GetUserList();
        Task<int> Login(UserInfoDto entity);
    }
}
