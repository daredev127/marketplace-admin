namespace Marketplace.Admin.Application.Features.AccountManagement.Seller.CreateSellerAccount
{
    public class CreateSellerAccountCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
