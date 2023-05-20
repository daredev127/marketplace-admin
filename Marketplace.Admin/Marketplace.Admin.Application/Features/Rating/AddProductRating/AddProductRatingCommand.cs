namespace Marketplace.Admin.Application.Features.Rating.AddProductRating
{
    public class AddProductRatingCommand
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
        public decimal Rating { get; set; }

        public AddProductRatingCommand(string productId, string productName, string username, string comment, decimal rating)
        {
            ProductId = productId;
            ProductName = productName;
            Username = username;
            Comment = comment;
            Rating = rating;
        }
    }
}
