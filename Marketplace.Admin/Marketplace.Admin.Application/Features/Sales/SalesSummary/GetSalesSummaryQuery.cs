namespace Marketplace.Admin.Application.Features.Sales.SalesSummary
{
    public class GetSalesSummaryQuery
    {
        public string Period { get; set; }
        public string Search { get; set; }

        public GetSalesSummaryQuery(string period, string search)
        {
            Period = period;
            Search = search;
        }
    }
}
