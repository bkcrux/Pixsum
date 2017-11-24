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

        public ICollection<AccountModel> GetAccounts()
        {
            return mapper.Map<IEnumerable<Account>, ICollection<AccountModel>>(_logic.GetAccounts());
        }


        public ICollection<AccountModel> GetAccountsForUser()
        {
            return null;
        }

        public void GetUsersOnAccount()
        { }

        public AccountModel CreateNewAccountForBrandNewUser(AccountModel account)
        {
            var o = _logic.Add(mapper.Map<AccountModel, Account>(account));
            return mapper.Map<Account, AccountModel>(o);
        }

        public AccountModel UpdateAccount(int id, AccountModel account)
        {
            //TODO: Validate passed-in account object
            var objFromDb = GetAccount(id);
            //Copy the values that should be updated over the obj from the db
            objFromDb = mapper.Map<AccountModel, AccountModel>(account, objFromDb);

            //covert to db entity
            var entity = mapper.Map<AccountModel, Account>(objFromDb);

            //Save changes
            entity = _logic.Update(entity);

            //Return model (dto)
            return mapper.Map<Account, AccountModel>(entity);
        }

        public void DeactivateAccount()
        { }


    }
}
