using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Demographics.Seller
{
    public interface IGetSellerDemographicsQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetSellerDemographicsQuery query);
    }
}
