using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCBlog.IBLL
{
    public interface IBlogArticleListVistor
    {
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateModel(Dto.BlogArticleListDto entity);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="size">条数</param>
        /// <returns></returns>
        List<Dto.BlogArticleListDto> GetList(int page, int size);
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        List<Dto.BlogArticleListDto> GetAllList();
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="entityId">实体主键</param>
        /// <returns></returns>
        Task<Dto.BlogArticleListDto> GetModel(int entityId);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<int> EditModel(Dto.BlogArticleListDto entity);
        /// <summary>
        /// 根据主键集合获取列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<Dto.BlogArticleListDto> GetListByIds(List<int> ids);
    }
}
