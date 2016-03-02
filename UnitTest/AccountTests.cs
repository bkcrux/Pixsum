using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixsum.Data;
using Pixsum.Entities;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void CreateAccount()
        {

            UnitOfWork uow = new UnitOfWork();

            Account a = new Account();
            a.AccountName = TestUtilities.RandomString(10, false);
            a.SubDomain = a.AccountName.ToLower();
            uow.AccountRepository.Add(a);
            uow.Save();

            Account b = uow.AccountRepository.GetByID(a.Id);
            Assert.AreEqual(b.AccountName, a.AccountName);
            
        }

        [TestMethod]
        public void ListAccount()
        {

            UnitOfWork uow = new UnitOfWork();

            var accounts = uow.AccountRepository.Get();
            foreach (var a in accounts)
            {
                System.Diagnostics.Debug.WriteLine(a.AccountName);
            }

            //Assert.AreEqual(b.AccountName, a.AccountName);

        }

    }
}
