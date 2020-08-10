using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FireVape.Interfaces.Data.Repositories
{
    public interface IRepository<T> : IAsyncEnumerable<T>, IAsyncDisposable, IAsyncSaveable where T : class, IEntity
    {
        Task<T> GetAsync(Guid guid);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> GetOneAsync(Expression<Func<T, bool>> predicate = null);
        Task<int> GetCountAsync(Expression<Func<T, bool>> predicate = null);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid guid);
    }
}
