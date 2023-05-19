namespace Marketplace.Admin.Application.Features.AccountManagement.Buyer.CreateBuyerAccount
{
    public class CreateBuyerAccountCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
