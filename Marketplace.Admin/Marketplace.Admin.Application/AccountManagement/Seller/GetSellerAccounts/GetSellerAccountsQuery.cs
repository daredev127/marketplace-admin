namespace Marketplace.Admin.Application.AccountManagement.Seller.GetSellerAccounts
{
    public class GetSellerAccountsQuery
    {
        public string Search { get; set; }
        public string Status { get; set; }

        public GetSellerAccountsQuery(string search, string status)
        {
            Search = search;
            Status = status;
        }
    }
}
