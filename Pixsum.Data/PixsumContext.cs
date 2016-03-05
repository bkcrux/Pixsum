using Pixsum.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixsum.Data
{
    public class PixsumContext : DbContext
    {
        public PixsumContext() : base("PixsumConnectionString")
        {
            //This initilizer needs to be called in order for the OnModelCreating handler to fire
            Database.SetInitializer<PixsumContext>(null);

#if DEBUG
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
#endif

        }

        public IDbSet<Account> AccountSet { get; set; }
        public IDbSet<AccountUser> AccountUserSet { get; set; }
        public IDbSet<Blog> BlogSet { get; set; }
        public IDbSet<BlogComment> BlogCommentSet { get; set; }
        public IDbSet<BlogContent> BlogContentSet { get; set; }
        public IDbSet<BlogContentComment> BlogContentCommentSet { get; set; }
        public IDbSet<BlogUser> BlogUserSet { get; set; }
        public IDbSet<User> UserSet { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Need to remove the pluralizing convention, otherwise EF will try to select from 'Accounts' instead of the real table name which is 'Account'
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            DateTime saveTime = DateTime.UtcNow;
            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                if (entry.Property("CreatedDate").CurrentValue == null)
                    entry.Property("CreatedDate").CurrentValue = saveTime;

                if (entry.Property("UpdatedDate").CurrentValue == null)
                    entry.Property("UpdatedDate").CurrentValue = saveTime;
            }

            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            {
                if (entry.Property("UpdatedDate").CurrentValue == null)
                    entry.Property("UpdatedDate").CurrentValue = saveTime;
            }

            return base.SaveChanges();
        }

    }
}
