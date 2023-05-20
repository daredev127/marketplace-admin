namespace Marketplace.Admin.Application.Features.Rating.GetProductRating
{
    public class GetProductRatingQuery
    {
        public string ProductId { get; set; }

        public GetProductRatingQuery(string productId)
        {
            ProductId = productId;
        }
    }
}
