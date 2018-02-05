using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ANC.Sales.Data.Entities;

namespace ANC.Sales.Data.Repositories
{
    public interface IGenericRepository<T>
        where T: BaseEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        long Count();
        long Count(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Update(T entry);
        void Delete(T entry);
    }
}