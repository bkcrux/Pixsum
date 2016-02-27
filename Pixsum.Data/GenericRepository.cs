using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class 
    {
        internal PixsumContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(PixsumContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

    }
}
