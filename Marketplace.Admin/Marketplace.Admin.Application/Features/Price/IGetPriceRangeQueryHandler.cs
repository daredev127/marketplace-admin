using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Price
{
    public interface IGetPriceRangeQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetPriceRangeQuery query);
    }
}
