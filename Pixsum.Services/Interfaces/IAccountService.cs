using Pixsum.Entities;
using Pixsum.Models;
using System.Collections.Generic;

namespace Pixsum.Services.Interfaces
{
    public interface IAccountService
    {
        AccountModel GetAccount(object id);
        ICollection<AccountModel> GetAccountsForUser();
        void GetUsersOnAccount();
        AccountModel CreateNewAccountForBrandNewUser(AccountModel account);
        AccountModel UpdateAccount(int id, AccountModel account);
        void DeactivateAccount();
    }
}