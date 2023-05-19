namespace Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.GetLogisticsStaffAccounts
{
    public class GetLogisticsStaffAccountsQuery
    {
        public string Search { get; set; }
        public string Status { get; set; }

        public GetLogisticsStaffAccountsQuery(string search, string status)
        {
            Search = search;
            Status = status;
        }
    }
}
