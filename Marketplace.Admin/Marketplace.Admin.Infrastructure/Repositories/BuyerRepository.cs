using Marketplace.Admin.Domain.Entities;
using Marketplace.Admin.Domain.Repositories;
using Marketplace.Admin.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Admin.Infrastructure.Repositories
{
    public class BuyerRepository : RepositoryBase<Buyer>, IBuyerRepository
    {
        public BuyerRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<Buyer> FindByUsername(string username)
        {
            var user = await _dbContext.Buyers
                .FirstOrDefaultAsync(x => x.Username == username);
            return user;
        }

        public async Task<IEnumerable<Buyer>> GetUsersBySearchAndStatus(string search, string status)
        {
            var users = await _dbContext.Buyers
                .Where(x => (string.IsNullOrEmpty(search) || (x.Username.Contains(search) || x.Name.Contains(search)))
                    && (string.IsNullOrEmpty(status) || x.Status == status))
                .ToListAsync();
            return users;
        }
    }
}
