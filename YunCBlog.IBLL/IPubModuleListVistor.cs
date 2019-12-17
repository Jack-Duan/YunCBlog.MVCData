using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.IBLL
{
    /// <summary>
    /// 模块管理
    /// </summary>
    public interface IPubModuleListVistor
    {
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<int> CreateModel(Dto.PubModuleDto entity);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="size">数量</param>
        /// <returns></returns>
        List<Dto.PubModuleDto> GetList(int page, int size);
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        List<Dto.PubModuleDto> GetAllList();
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="guid">实体guid</param>
        /// <returns></returns>
        Task<Dto.PubModuleDto> GetModel(Guid guid);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="entityId">实体主键</param>
        /// <returns></returns>
        Task<Dto.PubModuleDto> GetModel(int entityId);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<int> EditModel(Dto.PubModuleDto entity);
        /// <summary>
        /// 根据主键集合获取列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<Dto.PubModuleDto> GetListByIds(List<int> ids);
    }
}
