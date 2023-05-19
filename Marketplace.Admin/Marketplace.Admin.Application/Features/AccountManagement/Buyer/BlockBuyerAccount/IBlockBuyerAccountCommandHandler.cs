using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.AccountManagement.Buyer.BlockBuyerAccount
{
    public interface IBlockBuyerAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(BlockBuyerAccountCommand request);
    }
}
