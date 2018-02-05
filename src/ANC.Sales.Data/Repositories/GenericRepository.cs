using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ANC.Sales.Data.Context;
using ANC.Sales.Data.Entities;

namespace ANC.Sales.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        private readonly ApplicationContext _ctx;

        #region Ctor
        
        public GenericRepository(ApplicationContext ctx)
        {
            this._ctx = ctx;
        }

        #endregion Ctor


        #region Query methods

        public long Count()
        {
            throw new NotImplementedException();
        }

        public long Count(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion Query methods


        #region Control methods

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entry)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entry)
        {
            var t = _ctx.Set<T>().Remove(entry);
            
            // TODO: review how to return a bool?
        }

        #endregion Control methods
    }
}