using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.IBLL
{
    /// <summary>
    /// 文章类型与用户模块关联表
    /// </summary>
    public interface IArticleType_LinkVistor
    {
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateModel(Dto.ArticleType_LinkDto entity);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="size">条数</param>
        /// <returns></returns>
        List<Dto.ArticleType_LinkDto> GetList(int page, int size);
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        List<Dto.ArticleType_LinkDto> GetAllList();
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="entityId">实体主键</param>
        /// <returns></returns>
        Task<Dto.ArticleType_LinkDto> GetModel(int entityId);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<int> EditModel(Dto.ArticleType_LinkDto entity);
        /// <summary>
        /// 根据主键集合获取列表
        /// </summary>
        /// <param name="entityIds">主键集合</param>
        /// <returns></returns>
        Task<List<Dto.ArticleType_LinkDto>> GetListByIds(List<int> entityIds);
    }
}
