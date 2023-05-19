using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Sales.Common
{
    public interface ISalesHistoryService
    {
        Task<IEnumerable<SalesHistoryDto>> GetSalesHistory();
    }
}
