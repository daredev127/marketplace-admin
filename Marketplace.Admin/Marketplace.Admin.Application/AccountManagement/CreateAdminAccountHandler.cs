using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.AccountManagement
{
    public class CreateAdminAccountHandler
    {
        private readonly IAdminRepository _adminRepository;
        public CreateAdminAccountHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
    }
}
