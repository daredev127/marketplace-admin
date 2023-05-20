namespace Marketplace.Admin.Application.Dtos
{
    public class PriceRangeDto
    {
        public string ProductName { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal PriceDifference { get; set; }
    }
}
