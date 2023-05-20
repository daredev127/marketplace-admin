using Mapster;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Entities;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.Rating.AddProductRating
{
    public class AddProductRatingCommandHandler : IAddProductRatingCommandHandler
    {
        private readonly IProductRatingRepository _productRatingRepository;

        public AddProductRatingCommandHandler(IProductRatingRepository productRatingRepository)
        {
            _productRatingRepository = productRatingRepository;
        }

        public async Task<ResponseBaseDto> Handle(AddProductRatingCommand request)
        {
            var rating = await _productRatingRepository.AddAsync(new ProductRating
            {
                Username = request.Username,
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                Rating = request.Rating,
                Comment = request.Comment
            });

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = rating.Adapt<ProductRatingDto>()
            };
        }
    }
}
