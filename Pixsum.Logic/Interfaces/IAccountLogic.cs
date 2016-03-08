using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pixsum.Entities;

namespace Pixsum.Logic.Interfaces
{
    public interface IAccountLogic
    {
        void Add(Account entity);
        void Delete(object id);
        void Delete(Account entityToDelete);
        IEnumerable<Account> Get(Expression<Func<Account, bool>> filter = null, Func<IQueryable<Account>, IOrderedQueryable<Account>> orderBy = null, string includeProperties = "");
        Account GetByID(object id);
        void Update(Account entityToUpdate);
    }
}