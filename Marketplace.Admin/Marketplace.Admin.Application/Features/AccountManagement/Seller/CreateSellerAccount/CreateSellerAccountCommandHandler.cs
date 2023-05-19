using Mapster;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Auth;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.Seller.CreateSellerAccount
{
    public class CreateSellerAccountCommandHandler : ICreateSellerAccountCommandHandler
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IPasswordUtils _passwordUtil;
        public CreateSellerAccountCommandHandler(ISellerRepository sellerRepository, IPasswordUtils passwordUtil)
        {
            _sellerRepository = sellerRepository;
            _passwordUtil = passwordUtil;
        }

        public async Task<ResponseBaseDto> Handle(CreateSellerAccountCommand request)
        {
            if (await _sellerRepository.FindByUsername(request.Username) != null)
            {
                return new ResponseBaseDto { Status = "Error", Message = "Username already exists" };
            }

            var newSeller = request.Adapt<Domain.Entities.Seller>();
            newSeller.Password = _passwordUtil.GenerateHash(request.Password);
            newSeller.Status = Status.Active;
            newSeller.CreatedDate = DateTime.Now;
            newSeller.CreatedBy = "Seller";
            var sellerUser = await _sellerRepository.AddAsync(newSeller);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = sellerUser };
        }
    }
}

