using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Auth.Admin
{
    public interface IAdminLoginCommandHandler
    {
        Task<ResponseBaseDto> Handle(AdminLoginCommand request);
    }
}
