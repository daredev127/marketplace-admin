using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Common;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.Demographics.Buyer
{
    public class GetBuyerDemographicsQueryHandler : IGetBuyerDemographicsQueryHandler
    {
        private readonly IBuyerRepository _buyerRepository;
        private readonly IBuyerService _buyerService;

        public GetBuyerDemographicsQueryHandler(IBuyerRepository buyerRepository, IBuyerService buyerService)
        {
            _buyerRepository = buyerRepository;
            _buyerService = buyerService;
        }

        public async Task<ResponseBaseDto> Handle(GetBuyerDemographicsQuery query)
        {
            //var buyers = await _buyerRepository.GetAllAsync();
            var buyers = await _buyerService.GetBuyers();
            var totalBuyers = buyers.Count;

            var demographics = buyers.GroupBy(x => x.State).Select(
                x => new BuyerDemographicsDto
                {
                    Location = x.First().State,
                    BuyerCount = x.Count(),
                    Percentage = Math.Round(100m * x.Count() / totalBuyers, 2)
                }).OrderByDescending(x => x.BuyerCount);

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
