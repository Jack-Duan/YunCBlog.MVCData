﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunCBlog.IDAL;
using YunCBlog.Models;

namespace YunCBlog.DAL
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        private readonly BlogContext _db;
        public BaseService(BlogContext db)
        {
            _db = db;
        }

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
        public IQueryable<T> GetList(int page, int size, List<string> columns)
        {
            return GetAll().OrderByDescending(e => e.DisOrder).Skip(page * size).Take(size);
        }
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().Where(e => e.IsRemoved == false).AsNoTracking();
        }
        /// <summary>
        /// GetModel
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public async Task<T> GetModel(Guid entityId)
        {
            return await GetAll().FirstAsync(e => e.GuId == entityId);
        }

        public async Task CreateAsync(T model, bool saved = true)
        {
            _db.Set<T>().Add(model);
            if (saved) await _db.SaveChangesAsync();
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
            model.IsRemoved = true;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }

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
