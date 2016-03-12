using Pixsum.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Data
{
    //This class holds the pixsum context to the db that is used in each generic repo and the unit of work
    //The primary purpose is for calling the EF savechanges() and to dispose of the db context correctly.
    public class DbFactory : IDbFactory
    {
        private PixsumContext pc;

        public PixsumContext Initialize()
        {
            return pc ?? (pc = new PixsumContext());
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    pc.Dispose();
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
