using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.AccountManagement.Admin.UnblockAdminAccount
{
    public interface IUnblockAdminAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(UnblockAdminAccountCommand request);
    }
}
