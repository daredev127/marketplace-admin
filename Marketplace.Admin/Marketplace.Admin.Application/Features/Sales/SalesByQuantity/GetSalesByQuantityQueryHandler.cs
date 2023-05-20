using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Sales.Common;
using Marketplace.Admin.Domain.Constants;

namespace Marketplace.Admin.Application.Features.Sales.SalesByQuantity
{
    public class GetSalesByQuantityQueryHandler : IGetSalesByQuantityQueryHandler
    {
        private readonly ISalesHistoryService _salesHistoryService;

        public GetSalesByQuantityQueryHandler(ISalesHistoryService salesHistoryService)
        {
            _salesHistoryService = salesHistoryService;
        }

        public async Task<ResponseBaseDto> Handle(GetSalesByQuantityQuery query)
        {
            var salesHistory = await _salesHistoryService.GetSalesHistory();
            var salesByQuantity = salesHistory.GroupBy(x => x.ProductName).Select(x => new SalesByQuantityDto
            {
                ProductName = x.First().ProductName,
                Quantity = x.Sum(y => y.Quantity)
            }).OrderByDescending(x => x.Quantity);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = salesByQuantity
            };
        }
    }
}
