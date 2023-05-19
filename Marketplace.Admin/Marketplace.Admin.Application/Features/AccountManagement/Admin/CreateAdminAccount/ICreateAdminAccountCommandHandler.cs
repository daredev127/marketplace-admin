using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.AccountManagement.Admin.CreateAdminAccount
{
    public interface ICreateAdminAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(CreateAdminAccountCommand request);
    }
}
