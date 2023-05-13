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

        //A function that accepts username and password and verifies if it is in the database
        public async Task<bool> VerifyAdminAccount(string username, string password)
        {
            var authenticated = await _adminRepository.Authenticate(username, password);
            return authenticated;
        }
    }
}
