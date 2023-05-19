namespace Marketplace.Admin.Application.Dtos
{
    public class SellerDemographicsResponseDto
    {
        public int TotalSellers { get; set; }
        public IEnumerable<SellerDemographicsDto> Demographics { get; set; }
    }
}
