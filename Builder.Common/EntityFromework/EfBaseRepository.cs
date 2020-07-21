using Builder.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Common.EntityFromework
{
    public class EfBaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>        where TEntity : BaseEntity<TKey>
    {
        private DbContext _db;
        private DbSet<TEntity> _dbSet; 

        public EfBaseRepository(DbContext db)
        {
            _db = db;

            _dbSet = _db.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public long Count(Expression<Func<TEntity, bool>> predict)
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAsync(Expression<Func<TEntity, bool>> predict)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predict)
        {
            return _dbSet.FirstOrDefault(predict);
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predict)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predict)
        {
            return await _dbSet.Where(predict).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predict)
        {
            return await _dbSet.FirstOrDefaultAsync(predict);
        }

        public Task<TEntity> GetIncludesAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public TEntity GetIncluding(Expression<Func<TEntity, object>> including, Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetIncludingAsync(Expression<Func<TEntity, object>> including, Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predict)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predict)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetListIncludesAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetListIncluding(Expression<Func<TEntity, object>> including, Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetListIncludingAsync(Expression<Func<TEntity, object>> including, Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetListIncludingAsync(Expression<Func<TEntity, object>> including)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
