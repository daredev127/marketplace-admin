using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.Auth.LogisticsStaff
{
    public class LogisticsStaffLoginCommandHandler : ILogisticsStaffLoginCommandHandler
    {
        private readonly ILogisticsStaffRepository _logisticsStaffRepository;
        private readonly IPasswordUtils _passwordUtil;
        private readonly IJwtUtils _jwtUtils;
        public LogisticsStaffLoginCommandHandler(ILogisticsStaffRepository logisticsStaffRepository, IPasswordUtils passwordUtil, IJwtUtils jwtUtils)
        {
            _logisticsStaffRepository = logisticsStaffRepository;
            _passwordUtil = passwordUtil;
            _jwtUtils = jwtUtils;
        }

        public async Task<ResponseBaseDto> Handle(LogisticsStaffLoginCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return new ResponseBaseDto { Status = RequestStatus.Error, Message = ErrorMessages.INCORRECT_LOGIN, Data = null };

            var logisticsStaff = await _logisticsStaffRepository.FindByUsername(request.Username);
            if (logisticsStaff == null || !_passwordUtil.Validate(logisticsStaff.Password, request.Password))
            {
                return new ResponseBaseDto { Status = RequestStatus.Error, Message = ErrorMessages.INCORRECT_LOGIN, Data = null };
            }

            var token = _jwtUtils.GenerateJwtToken(logisticsStaff.Username);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = new LoginResponseDto
                {
                    Id = logisticsStaff.Id,
                    Username = logisticsStaff.Username,
                    Token = token
                }
            };
        }
    }
}
