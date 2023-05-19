using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.Auth.Buyer
{
    public class BuyerLoginCommandHandler : IBuyerLoginCommandHandler
    {
        private readonly IBuyerRepository _buyerRepository;
        private readonly IPasswordUtils _passwordUtil;
        private readonly IJwtUtils _jwtUtils;
        public BuyerLoginCommandHandler(IBuyerRepository buyerRepository, IPasswordUtils passwordUtil, IJwtUtils jwtUtils)
        {
            _buyerRepository = buyerRepository;
            _passwordUtil = passwordUtil;
            _jwtUtils = jwtUtils;
        }

        public async Task<ResponseBaseDto> Handle(BuyerLoginCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return new ResponseBaseDto { Status = RequestStatus.Error, Message = ErrorMessages.INCORRECT_LOGIN, Data = null };

            var buyer = await _buyerRepository.FindByUsername(request.Username);
            if (buyer == null || !_passwordUtil.Validate(buyer.Password, request.Password))
            {
                return new ResponseBaseDto { Status = RequestStatus.Error, Message = ErrorMessages.INCORRECT_LOGIN, Data = null };
            }

            var token = _jwtUtils.GenerateJwtToken(buyer.Username);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = new LoginResponseDto
                {
                    Id = buyer.Id,
                    Username = buyer.Username,
                    Token = token
                }
            };
        }
    }
}
