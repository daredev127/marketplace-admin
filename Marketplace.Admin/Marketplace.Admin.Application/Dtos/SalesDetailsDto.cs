namespace Marketplace.Admin.Application.Dtos
{
    public class SalesDetailsDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalSales { get; set; }
    }
}
