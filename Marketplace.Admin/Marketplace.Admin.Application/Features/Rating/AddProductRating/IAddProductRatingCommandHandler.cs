using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Rating.AddProductRating
{
    public interface IAddProductRatingCommandHandler
    {
        Task<ResponseBaseDto> Handle(AddProductRatingCommand request);
    }
}
