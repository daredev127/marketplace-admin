using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Sales.ProductSalesDetails
{
    public interface IGetProductSalesDetailsQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetProductSalesDetailsQuery query);
    }
}
