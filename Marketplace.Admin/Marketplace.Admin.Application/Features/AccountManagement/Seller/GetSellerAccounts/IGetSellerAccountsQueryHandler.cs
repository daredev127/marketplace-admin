using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.AccountManagement.Seller.GetSellerAccounts
{
    public interface IGetSellerAccountsQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetSellerAccountsQuery request);
    }
}
