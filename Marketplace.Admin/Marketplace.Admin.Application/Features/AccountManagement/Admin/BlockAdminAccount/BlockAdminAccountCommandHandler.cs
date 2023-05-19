using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.Admin.BlockAdminAccount
{
    public class BlockAdminAccountCommandHandler : IBlockAdminAccountCommandHandler
    {
        private readonly IAdminRepository _adminRepository;
        public BlockAdminAccountCommandHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<ResponseBaseDto> Handle(BlockAdminAccountCommand request)
        {
            var adminUser = await _adminRepository.FindByUsername(request.Username);
            if (adminUser != null)
            {
                adminUser.Status = Status.Blocked;
            }
            await _adminRepository.UpdateAsync(adminUser);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = adminUser };
        }
    }
}
