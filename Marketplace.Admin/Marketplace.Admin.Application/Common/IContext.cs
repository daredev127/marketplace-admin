using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Marketplace.Admin.Application.Common
{
    public interface IContext : IAsyncDisposable, IDisposable
    {
        public DatabaseFacade Database { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
