using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Sales.SalesByQuantity
{
    public interface IGetSalesByQuantityQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetSalesByQuantityQuery query);
    }
}
