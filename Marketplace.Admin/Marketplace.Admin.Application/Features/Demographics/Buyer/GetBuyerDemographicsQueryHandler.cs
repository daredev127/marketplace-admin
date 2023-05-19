using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.Demographics.Buyer
{
    public class GetBuyerDemographicsQueryHandler : IGetBuyerDemographicsQueryHandler
    {
        private readonly IBuyerRepository _buyerRepository;

        public GetBuyerDemographicsQueryHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<ResponseBaseDto> Handle(GetBuyerDemographicsQuery query)
        {
            var buyers = await _buyerRepository.GetAllAsync();
            var totalBuyers = buyers.Count;

            var demographics = buyers.GroupBy(x => x.Address).Select(
                x => new BuyerDemographicsDto
                {
                    Location = x.First().Address,
                    BuyerCount = x.Count(),
                    Percentage = Math.Round(100m * x.Count() / totalBuyers, 2)
                });

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = new BuyerDemographicsResponseDto
                {
                    TotalBuyers = totalBuyers,
                    Demographics = demographics
                }
            };
        }
    }
}
