using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Auth.Seller
{
    public interface ISellerLoginCommandHandler
    {
        Task<ResponseBaseDto> Handle(SellerLoginCommand request);
    }
}
