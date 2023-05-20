using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Sales.Common;
using Marketplace.Admin.Domain.Constants;

namespace Marketplace.Admin.Application.Features.Sales.ProductSalesDetails
{
    public class GetProductSalesDetailsQueryHandler : IGetProductSalesDetailsQueryHandler
    {
        private readonly ISalesHistoryService _salesHistoryService;

        public GetProductSalesDetailsQueryHandler(ISalesHistoryService salesHistoryService)
        {
            _salesHistoryService = salesHistoryService;
        }

        public async Task<ResponseBaseDto> Handle(GetProductSalesDetailsQuery query)
        {
            var salesHistory = await _salesHistoryService.GetSalesHistory();
            var salesByLocation = salesHistory.Where(x => x.ProductName == query.ProductName)
                .Select(x => new SalesByLocationDto
                {
                    ProductName = x.ProductName,
                    Quantity = x.Quantity,
                    Location = x.BuyerLocation
                }).OrderByDescending(x => x.Quantity); ;

            var simpleSalesHistory = salesHistory.Where(x => x.ProductName == query.ProductName)
                .Select(x => new SimpleSalesHistoryDto
                {
                    ProductName = x.ProductName,
                    Quantity = x.Quantity,
                    TimeStamp = x.Timestamp
                }).OrderBy(x => x.TimeStamp);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = new ProductSalesDetailsDto
                {
                    SalesByLocation = salesByLocation,
                    SalesHistory = simpleSalesHistory
                }
            };
        }
    }
}
