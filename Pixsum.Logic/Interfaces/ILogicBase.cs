using Pixsum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pixsum.Logic.Interfaces
{
    public interface ILogicBase<TEntity> 
    {
        void Add(TEntity entity);
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity GetByID(object id);
        TEntity Update(TEntity entityToUpdate);
    }
}