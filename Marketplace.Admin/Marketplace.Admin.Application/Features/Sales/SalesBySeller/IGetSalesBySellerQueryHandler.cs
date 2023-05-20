using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Sales.SalesBySeller
{
    public interface IGetSalesBySellerQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetSalesBySellerQuery query);
    }
}
