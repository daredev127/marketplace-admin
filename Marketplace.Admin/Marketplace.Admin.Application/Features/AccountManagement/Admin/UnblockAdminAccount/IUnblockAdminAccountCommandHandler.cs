using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.AccountManagement.Admin.UnblockAdminAccount
{
    public interface IUnblockAdminAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(UnblockAdminAccountCommand request);
    }
}
