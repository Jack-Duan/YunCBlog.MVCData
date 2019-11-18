using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.IBLL
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    public interface IPubMenuVistor
    {
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateModel(Dto.PubMenuDto entity);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="size">条数</param>
        /// <returns></returns>
        List<Dto.PubMenuDto> GetList(int page, int size);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="entityId">实体主键</param>
        /// <returns></returns>
        Task<Dto.PubMenuDto> GetModel(int entityId);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<int> EditModel(Dto.PubMenuDto entity);
    }
}
