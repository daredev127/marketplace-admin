using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Rating.GetProductRating
{
    public interface IGetProductRatingQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetProductRatingQuery query);
    }
}
