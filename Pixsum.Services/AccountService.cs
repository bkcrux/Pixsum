using Pixsum.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Services
{
    //AccountService Overview
    //Orchestration of bulk operations or complex business requirements
    //Database transactions captures at the service level
    //Deferred operations that are pushed to a queue or message bus such as emails, activities, logs, etc
    //Translates between Models and Entities

    public class AccountService
    {
        private IAccountLogic _accountLogic;
        
        public AccountService(IAccountLogic al)
        {
            _accountLogic = al;
        }

        void GetAccount()
        { }

        void GetAccountsForUser()
        { }

        void GetUsersOnAccount()
        { }

        void CreateNewAccountForBrandNewUser()
        { }

        void UpdateAccount()
        { }

        void DeactivateAccount()
        { }





    }
}
