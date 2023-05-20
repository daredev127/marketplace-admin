using Marketplace.Admin.Domain.Entities;
using Marketplace.Admin.Domain.Repositories;
using Marketplace.Admin.Infrastructure.Persistence.Database;

namespace Marketplace.Admin.Infrastructure.Repositories
{
    public class ProductRatingRepository : RepositoryBase<ProductRating>, IProductRatingRepository
    {
        public ProductRatingRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
