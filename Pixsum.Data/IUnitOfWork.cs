using Pixsum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Data
{
 
   public interface IUnitOfWork 
    {

        IGenericRepository<Account> AccountRepository { get; }
        IGenericRepository<AccountUser> AccountUserRepository { get; }
        IGenericRepository<Blog> BlogRepository { get; }
        IGenericRepository<BlogComment> BlogCommentRepository { get; }
        IGenericRepository<BlogContent> BlogContentRepository { get; }
        IGenericRepository<BlogContentComment> BlogContentCommentRepository { get; }
        IGenericRepository<BlogUser> BlogUserRepository { get; }
        IGenericRepository<User> UserRepository { get; }

        void Save();
    }
}
