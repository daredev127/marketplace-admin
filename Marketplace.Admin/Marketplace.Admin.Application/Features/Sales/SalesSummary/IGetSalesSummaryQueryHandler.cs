using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Sales.SalesSummary
{
    public interface IGetSalesSummaryQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetSalesSummaryQuery query);
    }
}
