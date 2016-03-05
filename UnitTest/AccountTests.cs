using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixsum.Data;
using Pixsum.Entities;
using System.Text;
using System.Linq;

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

            //var accounts = uow.AccountRepository.Get(null, q => q.OrderBy(a => a.UpdatedDate));
            var accounts = uow.AccountRepository.Get(filter: q => q.AccountName.Contains("cc"), orderBy: o => o.OrderByDescending(f => f.UpdatedDate));


            foreach (var a in accounts)
            {
                System.Diagnostics.Debug.WriteLine(a.AccountName + " " + a.UpdatedDate);
            }

            //Assert.AreEqual(b.AccountName, a.AccountName);

        }

    }
}
