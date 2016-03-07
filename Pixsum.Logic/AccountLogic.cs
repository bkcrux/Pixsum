using Pixsum.Data;
using Pixsum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Logic
{
    public class AccountLogic
    {
        private IUnitOfWork _uow;
        private IGenericRepository<Account> _accountRepo;


        public AccountLogic(IUnitOfWork unitOfWork,
            IGenericRepository<Account> accountRepo)
        {
            _uow = unitOfWork;
            _accountRepo = accountRepo;
        }

        public virtual IEnumerable<Account> GetAccountsWithAnX()
        {
            return _accountRepo.Get(filter: q => q.AccountName.Contains("X"), orderBy: o => o.OrderByDescending(f => f.UpdatedDate));
        }


        #region CRUD
        //CRUD
        public virtual Account GetByID(object id)
        {
            return _accountRepo.GetByID(id);
        }


        public virtual void Create(Account entity)
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
