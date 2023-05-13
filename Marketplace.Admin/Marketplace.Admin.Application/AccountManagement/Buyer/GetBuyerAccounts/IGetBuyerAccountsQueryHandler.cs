using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.AccountManagement.Buyer.GetBuyerAccounts
{
    public interface IGetBuyerAccountsQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetBuyerAccountsQuery request);
    }
}
