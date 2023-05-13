using Marketplace.Admin.Domain.Entities;

namespace Marketplace.Admin.Domain.Repositories
{
    public interface IBuyerRepository : IAsyncRepository<Buyer>
    {
        Task<IEnumerable<Buyer>> GetUsersBySearchAndStatus(string search, string status);
        Task<Buyer> FindByUsername(string username);
    }
}
