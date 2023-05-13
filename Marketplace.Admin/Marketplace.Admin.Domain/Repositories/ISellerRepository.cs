using Marketplace.Admin.Domain.Entities;

namespace Marketplace.Admin.Domain.Repositories
{
    public interface ISellerRepository : IAsyncRepository<Seller>
    {
        Task<IEnumerable<Seller>> GetUsersBySearchAndStatus(string search, string status);
        Task<Seller> FindByUsername(string username);
    }
}
