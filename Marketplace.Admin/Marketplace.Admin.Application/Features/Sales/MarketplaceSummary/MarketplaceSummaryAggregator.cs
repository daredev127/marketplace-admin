using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Sales.Common;
using Marketplace.Admin.Domain.Constants;

namespace Marketplace.Admin.Application.Features.Sales.MarketplaceSummary
{
    public class MarketplaceSummaryAggregator : IMarketplaceSummaryAggregator
    {
        private readonly ISalesHistoryService _salesHistoryService;

        public MarketplaceSummaryAggregator(ISalesHistoryService salesHistoryService)
        {
            _salesHistoryService = salesHistoryService;
        }

        public async Task<ResponseBaseDto> GetMarketplaceSummary()
        {
            var salesHistory = await _salesHistoryService.GetSalesHistory();

            var currentDate = DateTime.Now.Date;
            var dailySales = salesHistory.Where(x => x.Timestamp > currentDate).Sum(x => x.Price * x.Quantity);
            var weeklySales = salesHistory.Where(x => x.Timestamp > GetStartOfWeek()).Sum(x => x.Price * x.Quantity);
            var monthlySales = salesHistory.Where(x => x.Timestamp > GetStartOfMonth()).Sum(x => x.Price * x.Quantity);
            var annualSales = salesHistory.Where(x => x.Timestamp > GetStartOfYear()).Sum(x => x.Price * x.Quantity);
            var totalSales = salesHistory.Sum(x => x.Price * x.Quantity);

            var topSellers = salesHistory.GroupBy(x => x.SellerName).Select(x => new SellerSalesDto
            {
                Name = x.First().SellerName,
                Amount = x.Sum(y => y.Price * y.Quantity)
            }).OrderByDescending(x => x.Amount).Take(5);

            var topProducts = salesHistory.GroupBy(x => x.ProductName).Select(x => new ProductSalesDto
            {
                ProductName = x.First().ProductName,
                Amount = x.Sum(y => y.Price * y.Quantity)
            }).OrderByDescending(x => x.Amount).Take(5);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = new MarketplaceSummaryDto
                {
                    DailySales = dailySales,
                    WeeklySales = weeklySales,
                    MonthlySales = monthlySales,
                    AnnualSales = annualSales,
                    TotalSales = totalSales,
                    TopSellers = topSellers,
                    TopProducts = topProducts
                }
            };
        }

        private DateTime GetStartOfWeek()
        {
            var currentDate = DateTime.Now.Date;
            int diff = (7 + (currentDate.DayOfWeek - DayOfWeek.Monday)) % 7;
            return currentDate.AddDays(-1 * diff).Date;
        }

        private DateTime GetStartOfMonth()
        {
            var currentDate = DateTime.Now.Date;
            return new DateTime(currentDate.Year, currentDate.Month, 1);
        }

        private DateTime GetStartOfYear()
        {
            var currentDate = DateTime.Now.Date;
            return new DateTime(currentDate.Year, 1, 1);
        }
    }
}
