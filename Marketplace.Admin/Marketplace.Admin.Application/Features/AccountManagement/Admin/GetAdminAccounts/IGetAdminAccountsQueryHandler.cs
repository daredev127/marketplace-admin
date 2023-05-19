using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.AccountManagement.Admin.GetAdminAccounts
{
    public interface IGetAdminAccountsQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetAdminAccountsQuery request);
    }
}
