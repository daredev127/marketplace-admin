using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Sales.Common;
using Marketplace.Admin.Domain.Constants;

namespace Marketplace.Admin.Application.Features.Sales.SalesSummary
{
    public class GetSalesSummaryQueryHandler : IGetSalesSummaryQueryHandler
    {
        private readonly ISalesHistoryService _salesHistoryService;

        public GetSalesSummaryQueryHandler(ISalesHistoryService salesHistoryService)
        {
            _salesHistoryService = salesHistoryService;
        }

        public async Task<ResponseBaseDto> Handle(GetSalesSummaryQuery query)
        {
            var salesHistory = await _salesHistoryService.GetSalesHistory();
            var totalSales = salesHistory.Sum(x => x.Quantity * x.Price);
            var details = salesHistory.Select(x => new SalesDetailsDto
            {
                ProductName = x.ProductName,
                Price = x.Price,
                Quantity = x.Quantity,
                TotalSales = x.Price * x.Quantity
            }).OrderBy(x => x.ProductName).ThenByDescending(x => x.TotalSales);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = new SalesSummaryDto
                {
                    TotalSales = totalSales,
                    Details = details
                }
            };
        }
    }
}
