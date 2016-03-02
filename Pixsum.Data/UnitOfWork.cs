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
        private IGenericRepository<AccountUser> accountUserRepo;
        private IGenericRepository<Blog> blogRepo;
        private IGenericRepository<BlogComment> blogCommentRepo;
        private IGenericRepository<BlogContent> blogContentRepo;
        private IGenericRepository<BlogContentComment> blogContentCommentRepo;
        private IGenericRepository<BlogUser> blogUserRepo;
        private IGenericRepository<User> userRepo;

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
        public IGenericRepository<AccountUser> AccountUserRepository
        {
            get
            {
                if (this.accountUserRepo == null)
                {
                    this.accountUserRepo = new GenericRepository<AccountUser>(context);
                }
                return accountUserRepo;
            }
        }

        public IGenericRepository<Blog> BlogRepository
        {
            get
            {
                if (this.blogRepo == null)
                {
                    this.blogRepo = new GenericRepository<Blog>(context);
                }
                return blogRepo;
            }
        }

        public IGenericRepository<BlogComment> BlogCommentRepository
        {
            get
            {
                if (this.blogCommentRepo == null)
                {
                    this.blogCommentRepo = new GenericRepository<BlogComment>(context);
                }
                return blogCommentRepo;
            }
        }

        public IGenericRepository<BlogContent> BlogContentRepository
        {
            get
            {
                if (this.blogContentRepo == null)
                {
                    this.blogContentRepo = new GenericRepository<BlogContent>(context);
                }
                return blogContentRepo;
            }
        }

        public IGenericRepository<BlogContentComment> BlogContentCommentRepository
        {
            get
            {
                if (this.blogContentCommentRepo == null)
                {
                    this.blogContentCommentRepo = new GenericRepository<BlogContentComment>(context);
                }
                return blogContentCommentRepo;
            }
        }

        public IGenericRepository<BlogUser> BlogUserRepository
        {
            get
            {
                if (this.blogUserRepo == null)
                {
                    this.blogUserRepo = new GenericRepository<BlogUser>(context);
                }
                return blogUserRepo;
            }
        }

        public IGenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepo == null)
                {
                    this.userRepo = new GenericRepository<User>(context);
                }
                return userRepo;
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
