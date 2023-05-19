using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.Buyer.BlockBuyerAccount
{
    public class BlockBuyerAccountCommandHandler : IBlockBuyerAccountCommandHandler
    {
        private readonly IBuyerRepository _buyerRepository;
        public BlockBuyerAccountCommandHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<ResponseBaseDto> Handle(BlockBuyerAccountCommand request)
        {
            var BuyerUser = await _buyerRepository.FindByUsername(request.Username);
            if (BuyerUser != null)
            {
                BuyerUser.Status = Status.Blocked;
            }
            await _buyerRepository.UpdateAsync(BuyerUser);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = BuyerUser };
        }
    }
}
