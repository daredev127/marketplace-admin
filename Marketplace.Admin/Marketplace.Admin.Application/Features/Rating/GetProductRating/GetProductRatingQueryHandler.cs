using Mapster;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.Rating.GetProductRating
{
    public class GetProductRatingQueryHandler : IGetProductRatingQueryHandler
    {
        private readonly IProductRatingRepository _productRatingRepository;

        public GetProductRatingQueryHandler(IProductRatingRepository productRatingRepository)
        {
            _productRatingRepository = productRatingRepository;
        }

        public async Task<ResponseBaseDto> Handle(GetProductRatingQuery query)
        {
            var ratings = await _productRatingRepository.GetAsync(x => x.ProductId == query.ProductId);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = ratings.Adapt<IEnumerable<ProductRatingDto>>()
            };
        }
    }
}
