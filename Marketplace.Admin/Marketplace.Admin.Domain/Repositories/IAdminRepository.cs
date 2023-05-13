using Marketplace.Admin.Domain.Entities;

namespace Marketplace.Admin.Domain.Repositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<AdminUser>> GetAdminUsersBySearchAndStatus(string search, string status);
    }
}
