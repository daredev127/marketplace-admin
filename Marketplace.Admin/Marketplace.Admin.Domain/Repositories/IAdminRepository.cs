using Marketplace.Admin.Domain.Entities;

namespace Marketplace.Admin.Domain.Repositories
{
    public interface IAdminRepository : IAsyncRepository<AdminUser>
    {
        Task<IEnumerable<AdminUser>> GetUsersBySearchAndStatus(string search, string status);
        Task<AdminUser> FindByUsername(string username);
    }
}
