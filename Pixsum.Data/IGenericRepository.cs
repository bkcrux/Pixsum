using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Data
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetByID(object id);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(object id);
    }
}
