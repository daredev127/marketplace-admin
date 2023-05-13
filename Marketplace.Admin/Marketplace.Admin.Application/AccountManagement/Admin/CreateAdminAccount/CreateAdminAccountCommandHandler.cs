using Mapster;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Entities;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.AccountManagement.Admin.CreateAdminAccount
{
    public class CreateAdminAccountCommandHandler : ICreateAdminAccountCommandHandler
    {
        private readonly IAdminRepository _adminRepository;
        public CreateAdminAccountCommandHandler(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<ResponseBaseDto> Handle(CreateAdminAccountCommand request)
        {
            if (await _adminRepository.FindByUsername(request.Username) != null)
            {
                return new ResponseBaseDto { Status = "Error", Message = "Username already exists" };
            }

            var newAdminUser = request.Adapt<AdminUser>();
            newAdminUser.Status = Status.Active;
            newAdminUser.CreatedDate = DateTime.Now;
            newAdminUser.CreatedBy = "Admin";
            var adminUser = await _adminRepository.AddAsync(newAdminUser);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = adminUser };
        }
    }
}

