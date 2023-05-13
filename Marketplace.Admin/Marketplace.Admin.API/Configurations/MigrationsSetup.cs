using Marketplace.Admin.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Admin.API.Configurations
{
    public static class MigrationsSetup
    {
        public static async Task Migrate(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<IAssemblyMarker>>();
            var dbContext = scope.ServiceProvider.GetRequiredService<IContext>();

            logger.LogInformation("Running migrations...");
            await dbContext.Database.MigrateAsync();
            logger.LogInformation("Migrations applied succesfully");
        }
    }
}
