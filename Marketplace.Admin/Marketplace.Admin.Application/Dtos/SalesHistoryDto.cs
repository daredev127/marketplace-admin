namespace Marketplace.Admin.Application.Dtos
{
    public class SalesHistoryDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string SellerName { get; set; }
        public string BuyerLocation { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
