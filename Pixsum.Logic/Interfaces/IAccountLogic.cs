using System.Collections.Generic;
using Pixsum.Entities;

namespace Pixsum.Logic.Interfaces
{
    public interface IAccountLogic<TEntity> : ILogicBase<Account>
    {
        IEnumerable<Account> GetAccountsWithAnX();
    }
}