namespace Marketplace.Admin.Application.Features.Sales.SalesByQuantity
{
    public class GetSalesByQuantityQuery
    {
        public string Period { get; set; }
        public GetSalesByQuantityQuery(string period)
        {
            Period = period;
        }
    }
}
