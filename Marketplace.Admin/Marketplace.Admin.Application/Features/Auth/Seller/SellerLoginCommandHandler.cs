using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.Auth.Seller
{
    public class SellerLoginCommandHandler : ISellerLoginCommandHandler
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IPasswordUtils _passwordUtil;
        private readonly IJwtUtils _jwtUtils;
        public SellerLoginCommandHandler(ISellerRepository sellerRepository, IPasswordUtils passwordUtil, IJwtUtils jwtUtils)
        {
            _sellerRepository = sellerRepository;
            _passwordUtil = passwordUtil;
            _jwtUtils = jwtUtils;
        }

        public async Task<ResponseBaseDto> Handle(SellerLoginCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return new ResponseBaseDto { Status = RequestStatus.Error, Message = ErrorMessages.INCORRECT_LOGIN, Data = null };

            var seller = await _sellerRepository.FindByUsername(request.Username);
            if (seller == null || !_passwordUtil.Validate(seller.Password, request.Password))
            {
                return new ResponseBaseDto { Status = RequestStatus.Error, Message = ErrorMessages.INCORRECT_LOGIN, Data = null };
            }

            var token = _jwtUtils.GenerateJwtToken(seller.Username);

            return new ResponseBaseDto
            {
                Status = RequestStatus.OK,
                Message = "Success",
                Data = new LoginResponseDto
                {
                    Id = seller.Id,
                    Username = seller.Username,
                    Token = token
                }
            };
        }
    }
}
