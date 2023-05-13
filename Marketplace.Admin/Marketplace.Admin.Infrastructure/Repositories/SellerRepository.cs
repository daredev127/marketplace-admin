using Marketplace.Admin.Domain.Entities;
using Marketplace.Admin.Domain.Repositories;
using Marketplace.Admin.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Admin.Infrastructure.Repositories
{
    public class SellerRepository : RepositoryBase<Seller>, ISellerRepository
    {
        public SellerRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<Seller> FindByUsername(string username)
        {
            var user = await _dbContext.Sellers
                .FirstOrDefaultAsync(x => x.Username == username);
            return user;
        }

        public async Task<IEnumerable<Seller>> GetUsersBySearchAndStatus(string search, string status)
        {
            var users = await _dbContext.Sellers
                .Where(x => (string.IsNullOrEmpty(search) || (x.Username.Contains(search) || x.Name.Contains(search)))
                    && (string.IsNullOrEmpty(status) || x.Status == status))
                .ToListAsync();
            return users;
        }
    }
}
