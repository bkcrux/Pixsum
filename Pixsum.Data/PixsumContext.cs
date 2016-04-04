using Pixsum.Entities;
using Pixsum.Entities.Interfaces;
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

            var changeSet = ChangeTracker.Entries<IEntityAuditable>();
            {
                foreach (var entry in changeSet.Where(e => e.State == EntityState.Added))
                {
                    entry.Entity.CreatedDate = saveTime;
                }

                foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged))
                {
                    entry.Entity.UpdatedDate = saveTime;
                    //TODO inject username in constructor
                    //entry.Entity.ModifiedBy = HttpContext.Current.User.Identity.Name;
                    
                    //Ignore any changes to the createddate and createruser
                    entry.Property(p => p.CreatedDate).IsModified = false;
                    entry.Property(p => p.CreatedUserId).IsModified = false;
                }
            }

            return base.SaveChanges();
        }

    }
}
