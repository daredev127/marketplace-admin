using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Sales.SalesHistory
{
    public interface IGetSalesHistoryQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetSalesHistoryQuery query);
    }
}
