namespace Marketplace.Admin.Application.Features.Price
{
    public class GetPriceRangeQuery
    {
        public string Period { get; set; }

        public GetPriceRangeQuery(string period)
        {
            Period = period;
        }
    }
}
