using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.Seller.UnblockSellerAccount
{
    public class UnblockSellerAccountCommandHandler : IUnblockSellerAccountCommandHandler
    {
        private readonly ISellerRepository _sellerRepository;
        public UnblockSellerAccountCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<ResponseBaseDto> Handle(UnblockSellerAccountCommand request)
        {
            var seller = await _sellerRepository.FindByUsername(request.Username);
            if (seller != null)
            {
                seller.Status = Status.Active;
            }
            await _sellerRepository.UpdateAsync(seller);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = seller };
        }
    }
}
