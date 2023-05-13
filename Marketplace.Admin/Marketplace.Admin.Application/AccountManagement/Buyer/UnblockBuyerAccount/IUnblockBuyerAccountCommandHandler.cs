using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.AccountManagement.Buyer.UnblockBuyerAccount
{
    public interface IUnblockBuyerAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(UnblockBuyerAccountCommand request);
    }
}
