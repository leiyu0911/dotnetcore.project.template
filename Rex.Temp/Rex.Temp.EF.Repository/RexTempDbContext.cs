using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Rex.Temp.EF.Entity;

namespace Rex.Temp.EF.Repository
{
    public class RexTempDbContext : DbContext
    {
        public RexTempDbContext(DbContextOptions<RexTempDbContext> options)
            : base(options)
        {
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.UpdateBasicFields();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.UpdateBasicFields();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => p.IsDeleted == false);

            base.OnModelCreating(modelBuilder);
        }

        private void UpdateBasicFields()
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseEntity entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Detached:
                            break;
                        case EntityState.Unchanged:
                            break;
                        case EntityState.Deleted:
                            //逻辑删除 
                            entry.State = EntityState.Modified;
                            entity.IsDeleted = true;
                            break;
                        case EntityState.Modified:
                            entry.Property(nameof(entity.CreatedTime)).IsModified = false;
                            entity.LastModifiedTime = DateTime.Now;
                            break;
                        case EntityState.Added:
                            entity.CreatedTime = DateTime.Now;
                            entity.LastModifiedTime = DateTime.Now;
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        #region DbSet
        public DbSet<User> User { get; set; }
        #endregion
    }
}
