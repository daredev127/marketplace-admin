namespace Marketplace.Admin.Application.Dtos
{
    public class MarketplaceSummaryDto
    {
        public decimal DailySales { get; set; }
        public decimal WeeklySales { get; set; }
        public decimal MonthlySales { get; set; }
        public decimal AnnualSales { get; set; }
        public decimal TotalSales { get; set; }
        public IEnumerable<SellerSalesDto> TopSellers { get; set; }
        public IEnumerable<ProductSalesDto> TopProducts { get; set; }
        public IEnumerable<SellerRatingDto> BestSellers { get; set; }
        public IEnumerable<SellerSalesDto> WorstSellers { get; set; }

    }
}
