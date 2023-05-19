using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.AccountManagement.Seller.BlockSellerAccount
{
    public interface IBlockSellerAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(BlockSellerAccountCommand request);
    }
}
