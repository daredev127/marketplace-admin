using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Auth.Admin
{
    public interface IAdminLoginCommandHandler
    {
        Task<ResponseBaseDto> Handle(AdminLoginCommand request);
    }
}
