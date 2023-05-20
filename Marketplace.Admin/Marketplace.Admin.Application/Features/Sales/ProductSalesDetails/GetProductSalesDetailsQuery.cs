namespace Marketplace.Admin.Application.Features.Sales.ProductSalesDetails
{
    public class GetProductSalesDetailsQuery
    {
        public string Period { get; set; }
        public string ProductName { get; set; }

        public GetProductSalesDetailsQuery(string period, string productName)
        {
            Period = period;
            ProductName = productName;
        }
    }
}
