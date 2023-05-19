using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.AccountManagement.Seller.CreateSellerAccount
{
    public interface ICreateSellerAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(CreateSellerAccountCommand request);
    }
}
