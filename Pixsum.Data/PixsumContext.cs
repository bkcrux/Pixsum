using Pixsum.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        }

        public DbSet<Account> AccountSet { get; set; }
        public DbSet<AccountUser> AccountUserSet { get; set; }
        public DbSet<Blog> BlogSet { get; set; }
        public DbSet<BlogComment> BlogCommentSet { get; set; }
        public DbSet<BlogContent> BlogContentSet { get; set; }
        public DbSet<BlogContentComment> BlogContentCommentSet { get; set; }
        public DbSet<BlogUser> BlogUserSet { get; set; }
        public DbSet<User> UserSet { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Need to remove the pluralizing convention, otherwise EF will try to select from 'Accounts' instead of the real table name which is 'Account'
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //TODO make all the date defaults computed - so GETUTCDATE() in the db is called if no value is passed through
            //DatabaseGeneratedOption.Computed

            //TODO - set default of all dates in DB to GETUTCDATE()
        }



    }
}
