using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Demographics.Buyer
{
    public interface IGetBuyerDemographicsQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetBuyerDemographicsQuery query);
    }
}
