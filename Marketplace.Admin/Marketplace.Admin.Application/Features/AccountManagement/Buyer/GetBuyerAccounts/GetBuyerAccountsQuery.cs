namespace Marketplace.Admin.Application.Features.AccountManagement.Buyer.GetBuyerAccounts
{
    public class GetBuyerAccountsQuery
    {
        public string Search { get; set; }
        public string Status { get; set; }

        public GetBuyerAccountsQuery(string search, string status)
        {
            Search = search;
            Status = status;
        }
    }
}
