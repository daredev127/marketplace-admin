using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.Auth.Admin
{
    public class AdminLoginCommandHandler : IAdminLoginCommandHandler
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IPasswordUtils _passwordUtil;
        private readonly IJwtUtils _jwtUtils;
        public AdminLoginCommandHandler(IAdminRepository adminRepository, IPasswordUtils passwordUtil, IJwtUtils jwtUtils)
        {
            _adminRepository = adminRepository;
            _passwordUtil = passwordUtil;
            _jwtUtils = jwtUtils;
        }

        public async Task<ResponseBaseDto> Handle(AdminLoginCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return new ResponseBaseDto { Status = RequestStatus.Error, Message = ErrorMessages.INCORRECT_LOGIN, Data = null };

            var admin = await _adminRepository.FindByUsername(request.Username);
            if (admin == null || !_passwordUtil.Validate(admin.Password, request.Password))
            {
                return new ResponseBaseDto { Status = RequestStatus.Error, Message = ErrorMessages.INCORRECT_LOGIN, Data = null };
            }

            var token = _jwtUtils.GenerateJwtToken(admin.Username);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = new LoginResponseDto
                {
                    Id = admin.Id,
                    Username = admin.Username,
                    Token = token
                }
            };
        }
    }
}
