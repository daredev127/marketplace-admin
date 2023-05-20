namespace Marketplace.Admin.Application.Dtos
{
    public class ProductRatingDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
        public decimal Rating { get; set; }
    }
}
