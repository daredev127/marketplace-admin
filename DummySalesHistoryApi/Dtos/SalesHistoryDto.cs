namespace DummySalesHistoryApi.Dtos
{
    public class SalesHistoryDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string SellerName { get; set; }
        public string BuyerLocation { get; set; }
        public DateTime Timestamp { get; set; }

        public SalesHistoryDto(string productName, int quantity, decimal price, string sellerName, string buyerLocation, DateTime timestamp)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            SellerName = sellerName;
            BuyerLocation = buyerLocation;
            Timestamp = timestamp;
        }
    }
}
