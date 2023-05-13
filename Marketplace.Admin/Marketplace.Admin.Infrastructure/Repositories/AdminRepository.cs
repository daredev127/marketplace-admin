using Marketplace.Admin.Domain.Entities;
using Marketplace.Admin.Domain.Repositories;
using Marketplace.Admin.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Admin.Infrastructure.Repositories
{
    public class AdminRepository : RepositoryBase<AdminUser>, IAdminRepository
    {
        public AdminRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<AdminUser>> GetAdminUsersBySearchAndStatus(string search, string status)
        {
            var adminUsers = await _dbContext.AdminUsers
                .Where(x => (!string.IsNullOrEmpty(search) || (x.Username.Contains(search) || x.Name.Contains(search)))
                    && (!string.IsNullOrEmpty(status) || x.Status == status))
                .ToListAsync();
            return adminUsers;
        }
    }
}
