using Marketplace.Admin.Domain.Entities;

namespace Marketplace.Admin.Domain.Repositories
{
    public interface ILogisticsStaffRepository : IAsyncRepository<LogisticsStaff>
    {
        Task<IEnumerable<LogisticsStaff>> GetUsersBySearchAndStatus(string search, string status);
        Task<LogisticsStaff> FindByUsername(string username);
    }
}
