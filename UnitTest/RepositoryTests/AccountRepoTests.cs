using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixsum.Data;
using Pixsum.Entities;
using System.Text;
using System.Linq;

namespace UnitTest.RepositoryTests
{
    [TestClass]
    public class AccountRepoTests
    {
        [TestMethod]
        public void CreateAccount()
        {
            using (var db = new DbFactory())
            {
                var accRepo = new GenericRepository<Account>(db);
                var uow = new UnitOfWork(db);

                Account a = new Account();
                a.AccountName = TestUtilities.RandomString(10, false);
                a.SubDomain = a.AccountName.ToLower();
                accRepo.Add(a);
                uow.Save();

                Account b = accRepo.GetByID(a.Id);
                Assert.AreEqual(b.AccountName, a.AccountName);
            }

        }

        [TestMethod]
        public void ListAccount()
        {

            using (var db = new DbFactory())
            {
                var accRepo = new GenericRepository<Account>(db);
                var uow = new UnitOfWork(db);

                var accounts = accRepo.Get(orderBy: o => o.OrderByDescending(f => f.UpdatedDate));
                //var accounts = accRepo.Get(filter: q => q.AccountName.Contains("cc"), orderBy: o => o.OrderByDescending(f => f.UpdatedDate));

                foreach (var a in accounts)
                {
                    System.Diagnostics.Debug.WriteLine(a.AccountName + " " + a.UpdatedDate);
                }


            }

        }

        [TestMethod]
        public void Study()
        {
            Func<string, string> convertMethod = UppercaseString;
            Func<string, string> c = s => s.ToUpper();


            string name = "Dakota";
            // Use delegate instance to call UppercaseString method
            System.Diagnostics.Debug.WriteLine(c(name));

        }

        private static string UppercaseString(string inputString)
        {
            return inputString.ToUpper();
        }
    }
}
