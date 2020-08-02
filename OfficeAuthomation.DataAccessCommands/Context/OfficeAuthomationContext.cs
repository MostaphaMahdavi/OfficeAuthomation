using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OfficeAuthomation.Domains.Accounts.Roles.Entities;
using OfficeAuthomation.Domains.Accounts.Users.Entities;
using OfficeAuthomation.Domains.Commons;

namespace OfficeAuthomation.DataAccessCommands.Context
{
   public class OfficeAuthomationContext:IdentityDbContext<User,Role,string>
    {

        public OfficeAuthomationContext(DbContextOptions<OfficeAuthomationContext> options):base(options)
        {
            
        }



        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);


        }
        #endregion



        #region Save

        #region SaveChanges
        public override int SaveChanges()
        {
            CustomSaveChange();

            return base.SaveChanges();
        }

        #endregion

        #region SaveChanges

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            CustomSaveChange();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        #endregion

        #region SaveChangesAsync
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            CustomSaveChange();


            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region SaveChangesAsync

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            CustomSaveChange();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion


        #region CustomSaveChangeMethod

        private void CustomSaveChange()
        {

            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                                e.State == EntityState.Added
                                || e.State == EntityState.Modified));



            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                }
            }


        }

        #endregion

        #endregion


    }
}
