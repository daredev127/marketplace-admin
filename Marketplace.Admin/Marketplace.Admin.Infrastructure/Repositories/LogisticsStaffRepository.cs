using Marketplace.Admin.Domain.Entities;
using Marketplace.Admin.Domain.Repositories;
using Marketplace.Admin.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Admin.Infrastructure.Repositories
{
    public class LogisticsStaffRepository : RepositoryBase<LogisticsStaff>, ILogisticsStaffRepository
    {
        public LogisticsStaffRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<LogisticsStaff> FindByUsername(string username)
        {
            var user = await _dbContext.LogisticsStaff
                .FirstOrDefaultAsync(x => x.Username == username);
            return user;
        }

        public async Task<IEnumerable<LogisticsStaff>> GetUsersBySearchAndStatus(string search, string status)
        {
            var users = await _dbContext.LogisticsStaff
                .Where(x => (string.IsNullOrEmpty(search) || (x.Username.Contains(search) || x.Name.Contains(search)))
                    && (string.IsNullOrEmpty(status) || x.Status == status))
                .ToListAsync();
            return users;
        }
    }
}
