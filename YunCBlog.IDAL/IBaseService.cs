using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.Models;

namespace YunCBlog.IDAL
{
    /// <summary>
    /// Service实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T> : IDisposable where T : BaseEntity
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="saved">是否保存</param>
        /// <returns></returns>
        Task<int> CreateAsync(T model, bool saved = true);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="saved">是否保存</param>
        /// <returns></returns>
        Task EditAsync(T model, bool saved = true);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="saved">是否保存</param>
        /// <returns></returns>
        Task RemoveAsync(T model, bool saved = true);
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        Task Save();
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns></returns>
        Task<T> GetModel(Guid Guid);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="size">每页条数</param>
        /// <returns></returns>
        IQueryable<T> GetList(int page, int size);
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();
    }
}
