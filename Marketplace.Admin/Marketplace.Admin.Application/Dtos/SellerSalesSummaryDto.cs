namespace Marketplace.Admin.Application.Dtos
{
    public class SellerSalesSummaryDto
    {
        public decimal TotalSales { get; set; }
        public IEnumerable<SellerSalesDto> Details { get; set; }
    }
}
