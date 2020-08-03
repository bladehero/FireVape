using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FireVape.Interfaces.Data.Repositories
{
    public interface IRepository<T> : IEnumerable<T>, IEnumerable, IDisposable where T : class
    {
        T Get(Guid guid);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T GetOne(Expression<Func<T, bool>> predicate = null);
        int GetCount(Expression<Func<T, bool>> predicate = null);
        T Insert(T entity);
        T Update(T entity);
        bool Delete(Guid guid);

        void Save();
    }
}
