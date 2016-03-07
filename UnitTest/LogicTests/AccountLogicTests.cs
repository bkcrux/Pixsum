﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixsum.Data;
using Pixsum.Entities;
using Pixsum.Logic;

namespace UnitTest.LogicTests
{
    [TestClass]
    public class AccountLogicTests
    {
        [TestMethod]
        public void CreateAccount()
        {
            using (var db = new DbFactory())
            {
                var uow = new UnitOfWork(db);
                var repo = new GenericRepository<Account>(db);

                var al = new AccountLogic(uow, repo);

                Account a = new Account();
                a.AccountName = TestUtilities.RandomString(10, false);
                a.SubDomain = a.AccountName.ToLower();
                al.Create(a);

                Account b = al.GetByID(a.Id);
                Assert.AreEqual(b.AccountName, a.AccountName);


            }
        }

        [TestMethod]
        public void ListXAccounts()
        {
            using (var db = new DbFactory())
            {
                var uow = new UnitOfWork(db);
                var accRepo = new GenericRepository<Account>(db);

                var al = new AccountLogic(uow, accRepo);
                foreach (Account a in al.GetAccountsWithAnX())
                {
                    System.Diagnostics.Debug.WriteLine(a.AccountName + " " + a.UpdatedDate);
                }
            }
        }

    }
}