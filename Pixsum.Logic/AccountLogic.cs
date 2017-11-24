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
    public class AccountLogic<TEntity> : LogicBase<Account>, IAccountLogic<TEntity> where TEntity : class, IEntityBase
    {
        private IUnitOfWork _uow;
        private IGenericRepository<Account> _accountRepo;


        public AccountLogic(IUnitOfWork unitOfWork,
            IGenericRepository<Account> accountRepo)
            : base(unitOfWork, accountRepo)
        {
            _uow = unitOfWork;
            _accountRepo = accountRepo;
        }

        #region Special Methods
        public virtual IEnumerable<Account> GetAccounts()
        {
            return _accountRepo.Get(orderBy: o => o.OrderByDescending(f => f.UpdatedDate));
        }
        #endregion


    }
}
