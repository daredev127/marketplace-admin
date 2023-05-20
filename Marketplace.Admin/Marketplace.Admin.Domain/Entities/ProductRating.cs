using Marketplace.Admin.Domain.Entities.Common;

namespace Marketplace.Admin.Domain.Entities
{
    public class ProductRating : EntityBase
    {
        public string Username { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public string Comment { get; set; }
        public decimal Rating { get; set; }
    }
}
