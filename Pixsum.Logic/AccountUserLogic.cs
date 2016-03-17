using Pixsum.Data;
using Pixsum.Data.Interfaces;
using Pixsum.Entities;
using Pixsum.Entities.Interfaces;
using Pixsum.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Logic
{
    public class AccountUserLogic<TEntity> : LogicBase<AccountUser> where TEntity : class, IEntityBase
    {
        private IUnitOfWork _uow;
        private IGenericRepository<AccountUser> _repo;


        public AccountUserLogic(IUnitOfWork unitOfWork,
            IGenericRepository<AccountUser> repo)
            : base(unitOfWork, repo)
        {
            _uow = unitOfWork;
            _repo = repo;
        }

        #region Special Methods
        
        
        #endregion


    }
}
