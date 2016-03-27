using Pixsum.Entities;
using System.Collections.Generic;

namespace Pixsum.Services.Interfaces
{
    public interface IAccountService
    {
        Account GetAccount(object id);
        ICollection<Account> GetAccountsForUser();
        void GetUsersOnAccount();
        void CreateNewAccountForBrandNewUser();
        void UpdateAccount();
        void DeactivateAccount();
    }
}