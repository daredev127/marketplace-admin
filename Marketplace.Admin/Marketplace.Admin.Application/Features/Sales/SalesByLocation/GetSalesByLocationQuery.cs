namespace Marketplace.Admin.Application.Features.Sales.SalesByLocation
{
    public class GetSalesByLocationQuery
    {
        public string Period { get; set; }
        public GetSalesByLocationQuery(string period)
        {
            Period = period;
        }
    }
}
