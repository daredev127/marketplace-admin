namespace Marketplace.Admin.Application.Features.Sales.SalesHistory
{
    public class GetSalesHistoryQuery
    {
        public string Period { get; set; }

        public GetSalesHistoryQuery(string period)
        {
            Period = period;
        }
    }
}
