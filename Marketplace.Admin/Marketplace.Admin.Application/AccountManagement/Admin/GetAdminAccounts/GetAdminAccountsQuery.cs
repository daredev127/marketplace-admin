namespace Marketplace.Admin.Application.AccountManagement.Admin.GetAdminAccounts
{
    public class GetAdminAccountsQuery
    {
        public string Search { get; set; }
        public string Status { get; set; }

        public GetAdminAccountsQuery(string search, string status)
        {
            Search = search;
            Status = status;
        }
    }
}
