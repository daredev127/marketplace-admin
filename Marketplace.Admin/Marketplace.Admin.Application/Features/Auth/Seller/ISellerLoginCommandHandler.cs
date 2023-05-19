using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Auth.Seller
{
    public interface ISellerLoginCommandHandler
    {
        Task<ResponseBaseDto> Handle(SellerLoginCommand request);
    }
}
