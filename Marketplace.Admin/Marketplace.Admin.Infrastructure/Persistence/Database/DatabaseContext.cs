using Marketplace.Admin.Application.Common;
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
    }
}
