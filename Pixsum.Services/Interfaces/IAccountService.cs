using Pixsum.Entities;
using System.Collections.Generic;

namespace Pixsum.Services.Interfaces
{
    public interface IAccountService
    {
        Account GetAccount(object id);
        ICollection<Account> GetAccountsForUser();
        void GetUsersOnAccount();
        Account CreateNewAccountForBrandNewUser(Account account);
        Account UpdateAccount(Account account);
        void DeactivateAccount();
    }
}