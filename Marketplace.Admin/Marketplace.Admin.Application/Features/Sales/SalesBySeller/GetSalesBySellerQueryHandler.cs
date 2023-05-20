using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Sales.Common;
using Marketplace.Admin.Domain.Constants;

namespace Marketplace.Admin.Application.Features.Sales.SalesBySeller
{
    public class GetSalesBySellerQueryHandler : IGetSalesBySellerQueryHandler
    {
        private readonly ISalesHistoryService _salesHistoryService;

        public GetSalesBySellerQueryHandler(ISalesHistoryService salesHistoryService)
        {
            _salesHistoryService = salesHistoryService;
        }

        public async Task<ResponseBaseDto> Handle(GetSalesBySellerQuery query)
        {
            var salesHistory = await _salesHistoryService.GetSalesHistory();
            var totalSales = salesHistory.Sum(x => x.Quantity * x.Price);
            var details = salesHistory.GroupBy(x => x.SellerName).Select(x => new SellerSalesDto
            {
                Name = x.First().SellerName,
                Amount = x.Sum(y => y.Price * y.Quantity)
            }).OrderByDescending(x => x.Amount);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = new SellerSalesSummaryDto
                {
                    TotalSales = totalSales,
                    Details = details
                }
            };
        }
    }
}
