using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.Admin.UnblockAdminAccount
{
    public class UnblockAdminAccountCommandHandler : IUnblockAdminAccountCommandHandler
    {
        private readonly IAdminRepository _adminRepository;
        public UnblockAdminAccountCommandHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<ResponseBaseDto> Handle(UnblockAdminAccountCommand request)
        {
            var adminUser = await _adminRepository.FindByUsername(request.Username);
            if (adminUser != null)
            {
                adminUser.Status = Status.Active;
            }
            await _adminRepository.UpdateAsync(adminUser);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = adminUser };
        }
    }
}
