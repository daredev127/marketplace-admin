using Mapster;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Auth;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Entities;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.Admin.CreateAdminAccount
{
    public class CreateAdminAccountCommandHandler : ICreateAdminAccountCommandHandler
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IPasswordUtils _passwordUtil;
        public CreateAdminAccountCommandHandler(IAdminRepository adminRepository, IPasswordUtils passwordUtil)
        {
            _adminRepository = adminRepository;
            _passwordUtil = passwordUtil;
        }

        public async Task<ResponseBaseDto> Handle(CreateAdminAccountCommand request)
        {
            if (await _adminRepository.FindByUsername(request.Username) != null)
            {
                return new ResponseBaseDto { Status = "Error", Message = "Username already exists" };
            }

            var newAdminUser = request.Adapt<AdminUser>();
            newAdminUser.Password = _passwordUtil.GenerateHash(request.Password);
            newAdminUser.Status = Status.Active;
            newAdminUser.CreatedDate = DateTime.Now;
            newAdminUser.CreatedBy = "Admin";
            var adminUser = await _adminRepository.AddAsync(newAdminUser);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = adminUser };
        }
    }
}

