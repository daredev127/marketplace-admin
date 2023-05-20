using Marketplace.Admin.Domain.Repositories;
using Marketplace.Admin.Infrastructure.Persistence.Database;
using Marketplace.Admin.Infrastructure.Repositories;
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

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<ILogisticsStaffRepository, LogisticsStaffRepository>();
            services.AddScoped<IProductRatingRepository, ProductRatingRepository>();

            return services;
        }
    }
}
