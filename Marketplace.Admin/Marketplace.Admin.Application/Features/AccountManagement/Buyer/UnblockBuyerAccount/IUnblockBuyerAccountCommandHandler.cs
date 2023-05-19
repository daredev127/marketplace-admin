using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.AccountManagement.Buyer.UnblockBuyerAccount
{
    public interface IUnblockBuyerAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(UnblockBuyerAccountCommand request);
    }
}
