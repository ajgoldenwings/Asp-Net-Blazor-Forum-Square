using ForumSquare.Shared.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ForumSquare.Shared.Repositories
{
    public interface IRepository<T, TEntity> 
        where T : class 
        where TEntity : class
    {
        ICollection<TEntity> GetAll();
        Task<ICollection<TEntity>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(SearchOptions<T, TEntity> searchOptions, CancellationToken ct);
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);
        TEntity Find(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match);
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);
        TEntity Add(TEntity t);
        Task<TEntity> AddAsync(TEntity t);
        Task<TEntity> AddAsync(TEntity t, CancellationToken ct);
        TEntity Update(TEntity updated, int key);
        Task<TEntity> UpdateAsync(TEntity updated, int key);
        void Delete(TEntity t);
        Task<int> DeleteAsync(TEntity t);
        int Count();
        Task<int> CountAsync();
    }
}
