using Pixsum.Data;
using Pixsum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTheDB
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork uow = new UnitOfWork();

            //Account acc = uow.AccountRepository.GetByID(2);
            //Console.WriteLine("Testing basics");
            //Console.WriteLine("Account Name: {0}, Account Id: {1}", acc.AccountName, acc.Id);
            //User uc = acc.CreatedUser;
            //User up = acc.UpdatedUser;

            Account a = new Account();
            a.AccountName = "Test Account";
            a.SubDomain = "testacc";

            uow.AccountRepository.Add(a);
            uow.Save();

            Console.ReadLine();

        }
    }
}
