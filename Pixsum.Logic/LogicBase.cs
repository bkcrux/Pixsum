using Pixsum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Logic
{
    public class LogicBase<T>
    {

        private IUnitOfWork _uow;

        public LogicBase(IUnitOfWork unitOfWork)
        {
            //Set the passed in DAL (db context) UnitOfWork
            _uow = unitOfWork;
        }


        //CRUD
        //Cascading deletes?  Handle in processors?
        public virtual void Create(T entity)
        {
            //check security

            //run before processors

            //validate

            //call context/session/repo to create a new object
            //_uow.AccountRepository.Add(entity);
            //_uow.Save();

            //run after processors

        }

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
