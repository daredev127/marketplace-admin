using Marketplace.Admin.Application.Common;
using Marketplace.Admin.Domain.Entities;
using Marketplace.Admin.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;


namespace Marketplace.Admin.Infrastructure.Persistence.Database
{
    public class DatabaseContext : DbContext, IContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<LogisticsStaff> LogisticsStaff { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "admin";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "admin";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
