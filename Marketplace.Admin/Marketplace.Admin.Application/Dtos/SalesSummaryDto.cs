namespace Marketplace.Admin.Application.Dtos
{
    public class SalesSummaryDto
    {
        public decimal TotalSales { get; set; }
        public IEnumerable<SalesDetailsDto> Details { get; set; }
    }
}
