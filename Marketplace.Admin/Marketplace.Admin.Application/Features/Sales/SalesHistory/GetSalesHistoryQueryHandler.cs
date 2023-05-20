using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Sales.Common;
using Marketplace.Admin.Domain.Constants;

namespace Marketplace.Admin.Application.Features.Sales.SalesHistory
{
    public class GetSalesHistoryQueryHandler : IGetSalesHistoryQueryHandler
    {
        private readonly ISalesHistoryService _salesHistoryService;

        public GetSalesHistoryQueryHandler(ISalesHistoryService salesHistoryService)
        {
            _salesHistoryService = salesHistoryService;
        }

        public async Task<ResponseBaseDto> Handle(GetSalesHistoryQuery query)
        {
            var salesHistory = await _salesHistoryService.GetSalesHistory();
            var simpleSalesHistory = salesHistory.Select(x => new SimpleSalesHistoryDto
            {
                ProductName = x.ProductName,
                Quantity = x.Quantity,
                TimeStamp = x.Timestamp
            }).OrderBy(x => x.TimeStamp);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = simpleSalesHistory
            };
        }
    }
}
