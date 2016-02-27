using Pixsum.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Data
{
    public class PixsumContext : DbContext
    {
        public PixsumContext() : base("PixsumConnectionString")
        {
        }

        public IDbSet<Account> AccountSet { get; set; }
        public IDbSet<AccountUser> AccountUserSet { get; set; }
        public IDbSet<Blog> BlogSet { get; set; }
        public IDbSet<BlogComment> BlogCommentSet { get; set; }
        public IDbSet<BlogContent> BlogContentSet { get; set; }
        public IDbSet<BlogContentComment> BlogContentCommentSet { get; set; }
        public IDbSet<BlogUser> BlogUserSet { get; set; }
        public IDbSet<User> UserSet { get; set; }

    }
}
