using Builder.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Common.EntityFromework
{
    public interface IRepository<T,TKey> where T : BaseEntity<TKey>
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<bool> AddRangeAsync(List<T> entities);
        void Delete(T entity);
        void Delete(TKey id);
        void Remove(T entity);
        T Update(T entity);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predict);
        T GetIncluding(Expression<Func<T, object>> including, Expression<Func<T, bool>> filter);
        Task<T> GetIncludingAsync(Expression<Func<T, object>> including, Expression<Func<T, bool>> filter);
        Task<bool> UpdateRangeAsync(IEnumerable<T> entities);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predict);
        IEnumerable<T> GetList(Expression<Func<T, bool>> predict);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predict);
        IEnumerable<T> GetListIncluding(Expression<Func<T, object>> including, Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetListIncludingAsync(Expression<Func<T, object>> including, Expression<Func<T, bool>> filter);
        IEnumerable<T> GetListIncludingAsync(Expression<Func<T, object>> including);
        void DeleteRange(IEnumerable<T> entities);
        T Get(Expression<Func<T, bool>> predict);
        Task<T> GetAsync(Expression<Func<T, bool>> predict);
        Task<long> CountAsync(Expression<Func<T, bool>> predict);
        long Count(Expression<Func<T, bool>> predict);
        Task<T> GetIncludesAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetListIncludesAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> UpdateAsync(T entity);
    }
}
