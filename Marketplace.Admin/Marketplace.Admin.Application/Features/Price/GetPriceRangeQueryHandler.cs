using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Sales.Common;
using Marketplace.Admin.Domain.Constants;

namespace Marketplace.Admin.Application.Features.Price
{
    public class GetPriceRangeQueryHandler : IGetPriceRangeQueryHandler
    {
        private readonly ISalesHistoryService _salesHistoryService;

        public GetPriceRangeQueryHandler(ISalesHistoryService salesHistoryService)
        {
            _salesHistoryService = salesHistoryService;
        }

        public async Task<ResponseBaseDto> Handle(GetPriceRangeQuery query)
        {
            var salesHistory = await _salesHistoryService.GetSalesHistory();
            var priceRange = salesHistory.GroupBy(x => x.ProductName)
                .Select(x => new PriceRangeDto
                {
                    ProductName = x.First().ProductName,
                    MinPrice = x.Min(x => x.Price),
                    MaxPrice = x.Max(x => x.Price),
                    PriceDifference = x.Max(x => x.Price) - x.Min(x => x.Price)
                }).OrderByDescending(x => x.PriceDifference);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = priceRange
            };
        }
    }
}
