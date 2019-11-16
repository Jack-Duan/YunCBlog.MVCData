using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.IDAL;
using YunCBlog.Models;

namespace YunCBlog.DAL
{
    /// <summary>
    /// Service基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        private readonly BlogContext _db;
        public BaseService(BlogContext db)
        {
            _db = db;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="saved">是否保存</param>
        /// <returns></returns>
        public async Task EditAsync(T model, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public IQueryable<T> GetList(int page, int size)
        {
            return GetAll().OrderByDescending(e => e.DisOrder).Skip(page * size).Take(size);
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().Where(e => e.IsRemoved == 0).AsNoTracking();
        }
        /// <summary>
        /// GetModel
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns></returns>
        public async Task<T> GetModel(Guid Guid)
        {
            return await GetAll().FirstAsync(e => e.GuId == Guid);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="saved">是否保存</param>
        /// <returns></returns>
        public async Task<int> CreateAsync(T model, bool saved = true)
        {
            try
            {
                _db.Set<T>().Add(model);
                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <param name="saved"></param>
        /// <returns></returns>
        public async Task RemoveAsync(T model, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Entry(model).State = EntityState.Unchanged;
            model.IsRemoved = 1;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public async Task Save()
        {
            await _db.SaveChangesAsync();
            _db.Configuration.ValidateOnSaveEnabled = true;
        }
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
