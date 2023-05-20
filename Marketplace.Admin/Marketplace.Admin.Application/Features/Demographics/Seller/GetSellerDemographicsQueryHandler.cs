using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.Demographics.Seller
{
    public class GetSellerDemographicsQueryHandler : IGetSellerDemographicsQueryHandler
    {
        private readonly ISellerRepository _sellerRepository;

        public GetSellerDemographicsQueryHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<ResponseBaseDto> Handle(GetSellerDemographicsQuery query)
        {
            var sellers = await _sellerRepository.GetAllAsync();
            var totalSellers = sellers.Count;

            var demographics = sellers.GroupBy(x => x.Address).Select(
                x => new SellerDemographicsDto
                {
                    Location = x.First().Address,
                    SellerCount = x.Count(),
                    Percentage = Math.Round(100m * x.Count() / totalSellers, 2)
                }).OrderByDescending(x => x.SellerCount);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = new SellerDemographicsResponseDto
                {
                    TotalSellers = totalSellers,
                    Demographics = demographics
                }
            };
        }
    }
}
