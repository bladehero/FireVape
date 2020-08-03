using FireVape.Interfaces.Data.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FireVape.Data
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public bool Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Get(Guid guid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T GetOne(Expression<Func<T, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public T Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
