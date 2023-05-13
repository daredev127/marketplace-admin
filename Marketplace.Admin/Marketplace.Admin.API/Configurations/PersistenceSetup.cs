using Marketplace.Admin.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Admin.API.Configurations
{
    public static class PersistanceSetup
    {
        public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DatabaseContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
