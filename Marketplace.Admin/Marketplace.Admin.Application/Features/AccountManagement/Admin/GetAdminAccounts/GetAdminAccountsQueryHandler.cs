using Mapster;
using Marketplace.Admin.Application.Common;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.Admin.GetAdminAccounts
{
    public class GetAdminAccountsQueryHandler : IGetAdminAccountsQueryHandler
    {
        private readonly IAdminRepository _adminRepository;

        public GetAdminAccountsQueryHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<ResponseBaseDto> Handle(GetAdminAccountsQuery request)
        {
            var adminUsers = await _adminRepository.GetUsersBySearchAndStatus(request.Search, request.Status);
            var adminUserDto = adminUsers.Adapt<IEnumerable<UserViewModel>>();
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = adminUserDto };
        }
    }
}
