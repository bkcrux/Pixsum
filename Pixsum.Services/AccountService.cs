using AutoMapper;
using Pixsum.Entities;
using Pixsum.Logic;
using Pixsum.Logic.Interfaces;
using Pixsum.Models;
using Pixsum.Services.Interfaces;
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

    public class AccountService : IAccountService
    {
        private IAccountLogic<Account> _logic;
        private IMapper mapper;

        public AccountService(IMapper mapper, IAccountLogic<Account> logic)
        {
            _logic = logic;
            this.mapper = mapper;
        }

        public AccountModel GetAccount(object id)
        {
            return mapper.Map<Account, AccountModel>(_logic.GetByID(id));
        }

        public ICollection<AccountModel> GetAccountsForUser()
        {
            return null;
        }

        public void GetUsersOnAccount()
        { }

        public AccountModel CreateNewAccountForBrandNewUser(AccountModel account)
        {
            _logic.Add(mapper.Map<AccountModel, Account>(account));
            return account;
        }

        public AccountModel UpdateAccount(int id, AccountModel account)
        {
            //TODO: Validate passed-in account object

            //Get original object values from db
            //TODO: Somehow this GET is causing the EF graph to load this specific object in memory, which
            //then causes issues in the generic repo when we try to attach and set to modified
            //Need to figure out a better way to say only modified changes with EF
            var objCurrent = GetAccount(id);
            //Copy any fields from the model (dto) to the existing obj
            mapper.Map<AccountModel, AccountModel>(account, objCurrent);
            //Convert to entity
            var entity = mapper.Map<AccountModel, Account>(objCurrent);
            //Save changes
            _logic.Update(entity);

            //Return model (dto)
            return mapper.Map<Account, AccountModel>(entity);
        }

        public void DeactivateAccount()
        { }


    }
}
