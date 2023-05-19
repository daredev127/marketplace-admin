using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.Buyer.UnblockBuyerAccount
{
    public class UnblockBuyerAccountCommandHandler : IUnblockBuyerAccountCommandHandler
    {
        private readonly IBuyerRepository _buyerRepository;
        public UnblockBuyerAccountCommandHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<ResponseBaseDto> Handle(UnblockBuyerAccountCommand request)
        {
            var buyerUser = await _buyerRepository.FindByUsername(request.Username);
            if (buyerUser != null)
            {
                buyerUser.Status = Status.Active;
            }
            await _buyerRepository.UpdateAsync(buyerUser);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = buyerUser };
        }
    }
}
