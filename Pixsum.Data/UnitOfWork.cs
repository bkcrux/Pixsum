using Pixsum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private PixsumContext context = new PixsumContext();
        private IGenericRepository<Account> accountRepo;
        //private IGenericRepository<AccountUser> accountUserRepo;

        public UnitOfWork()
        {
#if DEBUG
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
#endif
        }

        public IGenericRepository<Account> AccountRepository
        {
            get
            {
                if (this.accountRepo == null)
                {
                    this.accountRepo = new GenericRepository<Account>(context);
                }
                return accountRepo;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
    }
}
