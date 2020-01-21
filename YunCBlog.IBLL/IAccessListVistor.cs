using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.IBLL
{
    public interface IAccessListVistor
    {
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateModel(Dto.AccessListDto entity);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="size">条数</param>
        /// <returns></returns>
        List<Dto.AccessListDto> GetList(int page, int size);
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        List<Dto.AccessListDto> GetAllList();
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="entityId">实体主键</param>
        /// <returns></returns>
        Task<Dto.AccessListDto> GetModel(int entityId);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<int> EditModel(Dto.AccessListDto entity);
        /// <summary>
        /// 根据主键集合获取列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<Dto.AccessListDto> GetListByIds(List<int> ids);
    }
}
