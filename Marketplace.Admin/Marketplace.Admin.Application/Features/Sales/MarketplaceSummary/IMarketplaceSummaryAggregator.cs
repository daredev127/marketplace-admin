using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Sales.MarketplaceSummary
{
    public interface IMarketplaceSummaryAggregator
    {
        Task<ResponseBaseDto> GetMarketplaceSummary();
    }
}
