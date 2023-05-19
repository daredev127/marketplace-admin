namespace Marketplace.Admin.Application.Dtos
{
    public class BuyerDemographicsResponseDto
    {
        public int TotalBuyers { get; set; }
        public IEnumerable<BuyerDemographicsDto> Demographics { get; set; }
    }
}
