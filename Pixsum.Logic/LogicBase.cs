using Pixsum.Data;
using Pixsum.Data.Interfaces;
using Pixsum.Entities;
using Pixsum.Entities.Interfaces;
using Pixsum.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Logic
{
    public class LogicBase<TEntity> : ILogicBase<TEntity> where TEntity : class, IEntityBase
    {

        private IGenericRepository<TEntity> _repo;
        private IUnitOfWork _uow;

        public LogicBase(IUnitOfWork uow, IGenericRepository<TEntity> repo)
        {
            _repo = repo;
            _uow = uow;
        }


        public virtual TEntity GetByID(object id)
        {
            //passthrough to repo
            return _repo.GetByID(id);
        }

        public virtual IEnumerable<TEntity> Get(
                Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = "")
        {
            //passthrough to repo
            return _repo.Get(filter, orderBy, includeProperties);
        }


        public virtual void Add(TEntity entity)
        {
            //check security

            //run before processors

            //validate

            //call repo to create a new object
            _repo.Add(entity);
            //call unit of work to commit changes
            _uow.Save();

            //run after processors

        }


        public virtual void Update(TEntity entityToUpdate)
        {
            //passthrough to repo
            _repo.Update(entityToUpdate);
            //call unit of work to commit changes
            _uow.Save();
        }


        public virtual void Delete(object id)
        {
            //passthrough to repo
            _repo.Delete(id);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            //passthrough to repo
            _repo.Delete(entityToDelete);
        }


        //TODO
        //Cascading deletes?  Handle in processors?

        //Validation (BRs) - is this getting overkill?

        //Processors - is this getting overkill?

        //Security Trim (by account access)
        //Look at multi-tenant entity framework example
        //http://xabikos.com/multitenant/application%20design/software%20as%20a%20service/2014/11/18/create-a-multitenant-application-with-entity-framework-code-first---part-2.html
        //https://lostechies.com/jimmybogard/2014/05/29/missing-ef-feature-workarounds-filters/

        //Security by Object/Role in account

        //Caching - future phase

    }
}
