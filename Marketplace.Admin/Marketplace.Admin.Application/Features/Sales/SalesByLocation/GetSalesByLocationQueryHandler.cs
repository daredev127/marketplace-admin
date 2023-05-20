using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Sales.Common;
using Marketplace.Admin.Domain.Constants;

namespace Marketplace.Admin.Application.Features.Sales.SalesByLocation
{
    public class GetSalesByLocationQueryHandler : IGetSalesByLocationQueryHandler
    {
        private readonly ISalesHistoryService _salesHistoryService;

        public GetSalesByLocationQueryHandler(ISalesHistoryService salesHistoryService)
        {
            _salesHistoryService = salesHistoryService;
        }

        public async Task<ResponseBaseDto> Handle(GetSalesByLocationQuery query)
        {
            var salesHistory = await _salesHistoryService.GetSalesHistory();
            var salesByLocation = salesHistory.GroupBy(x => new { x.BuyerLocation, x.ProductName }).Select(x => new SalesByLocationDto
            {
                ProductName = x.First().ProductName,
                Quantity = x.Sum(y => y.Quantity),
                Location = x.First().BuyerLocation
            }).OrderBy(x => x.Location).ThenByDescending(x => x.Quantity);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = salesByLocation
            };
        }
    }
}
