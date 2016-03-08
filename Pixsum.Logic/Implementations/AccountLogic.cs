using Pixsum.Data;
using Pixsum.Entities;
using Pixsum.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Logic.Implementations
{
    public class AccountLogic : IAccountLogic
    {
        private IUnitOfWork _uow;
        private IGenericRepository<Account> _accountRepo;


        public AccountLogic(IUnitOfWork unitOfWork,
            IGenericRepository<Account> accountRepo)
        {
            _uow = unitOfWork;
            _accountRepo = accountRepo;
        }

        #region Special Methods
        public virtual IEnumerable<Account> GetAccountsWithAnX()
        {
            return _accountRepo.Get(filter: q => q.AccountName.Contains("X"), orderBy: o => o.OrderByDescending(f => f.UpdatedDate));
        }
        #endregion


        #region CRUD
        //CRUD
        public virtual IEnumerable<Account> Get(
                Expression<Func<Account, bool>> filter = null,
                Func<IQueryable<Account>, IOrderedQueryable<Account>> orderBy = null,
                string includeProperties = "")
        {
            //passthrough to repo
            return _accountRepo.Get(filter, orderBy, includeProperties);
        }


        public virtual Account GetByID(object id)
        {
            //passthrough to repo
            return _accountRepo.GetByID(id);
        }


        public virtual void Add(Account entity)
        {
            //check security

            //run before processors

            //validate

            //call repo to create a new object
            _accountRepo.Add(entity);
            //call unit of work to commit changes
            _uow.Save();

            //run after processors

        }

        public virtual void Update(Account entityToUpdate)
        {
            //passthrough to repo
            _accountRepo.Update(entityToUpdate);
        }


        public virtual void Delete(object id)
        {
            //passthrough to repo
            _accountRepo.Delete(id);
        }

        public virtual void Delete(Account entityToDelete)
        {
            //passthrough to repo
            _accountRepo.Delete(entityToDelete);
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

    #endregion

}
