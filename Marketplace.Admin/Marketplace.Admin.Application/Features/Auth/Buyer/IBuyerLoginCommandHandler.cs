using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Auth.Buyer
{
    public interface IBuyerLoginCommandHandler
    {
        Task<ResponseBaseDto> Handle(BuyerLoginCommand request);
    }
}
