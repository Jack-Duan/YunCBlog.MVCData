using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.IBLL
{
    /// <summary>
    /// 文章模块表
    /// </summary>
    public interface IArticleModuleVistor
    {
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateModel(Dto.ArticleModuleDto entity);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="size">条数</param>
        /// <returns></returns>
        List<Dto.ArticleModuleDto> GetList(int page, int size);
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        List<Dto.ArticleModuleDto> GetAllList();
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="entityId">实体主键</param>
        /// <returns></returns>
        Task<Dto.ArticleModuleDto> GetModel(int entityId);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<int> EditModel(Dto.ArticleModuleDto entity);
    }
}
