using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.AccountManagement.Seller.CreateSellerAccount
{
    public interface ICreateSellerAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(CreateSellerAccountCommand request);
    }
}
