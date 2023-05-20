using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Sales.SalesByLocation
{
    public interface IGetSalesByLocationQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetSalesByLocationQuery query);
    }
}
