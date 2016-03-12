using Pixsum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntityBase
    {
        TEntity GetByID(object id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = "");

        void Add(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(object id);
    }
}
