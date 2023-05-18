using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Auth.Buyer
{
    public interface IBuyerLoginCommandHandler
    {
        Task<ResponseBaseDto> Handle(BuyerLoginCommand request);
    }
}
