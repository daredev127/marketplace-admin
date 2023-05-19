namespace Marketplace.Admin.Application.Dtos
{
    public class ProductSalesDetailsDto
    {
        public IEnumerable<SimpleSalesHistoryDto> SalesHistory { get; set; }
        public IEnumerable<SalesByLocationDto> SalesByLocation { get; set; }
    }
}
