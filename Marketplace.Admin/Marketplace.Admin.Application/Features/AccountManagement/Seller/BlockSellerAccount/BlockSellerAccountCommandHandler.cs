using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.Seller.BlockSellerAccount
{
    public class BlockSellerAccountCommandHandler : IBlockSellerAccountCommandHandler
    {
        private readonly ISellerRepository _sellerRepository;
        public BlockSellerAccountCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<ResponseBaseDto> Handle(BlockSellerAccountCommand request)
        {
            var seller = await _sellerRepository.FindByUsername(request.Username);
            if (seller != null)
            {
                seller.Status = Status.Blocked;
            }
            await _sellerRepository.UpdateAsync(seller);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = seller };
        }
    }
}
