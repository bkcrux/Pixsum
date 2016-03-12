using Pixsum.Data.Interfaces;
using Pixsum.Entities;
using Pixsum.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntityBase
    {
        internal PixsumContext _dbcontext;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected PixsumContext DbContext
        {
            get { return _dbcontext ?? (_dbcontext = DbFactory.Initialize()); }
        }

        public GenericRepository(IDbFactory factory)
        {
            DbFactory = factory;
        }

        public virtual IEnumerable<TEntity> Get(
                Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = "")
        {
            IQueryable<TEntity> query = DbContext.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbContext.Set<TEntity>().Attach(entityToUpdate);
            DbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbContext.Set<TEntity>().Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbContext.Set<TEntity>().Attach(entityToDelete);
            }
            DbContext.Set<TEntity>().Remove(entityToDelete);
        }
    }
}
