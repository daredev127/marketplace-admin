namespace Marketplace.Admin.Application.Features.Sales.SalesBySeller
{
    public class GetSalesBySellerQuery
    {
        public string Period { get; set; }
        public string Search { get; set; }
        public GetSalesBySellerQuery(string period, string search)
        {
            Period = period;
            Search = search;
        }
    }
}
