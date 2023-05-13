using Mapster;
using Marketplace.Admin.Application.Common;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.AccountManagement.Buyer.GetBuyerAccounts
{
    public class GetBuyerAccountsQueryHandler : IGetBuyerAccountsQueryHandler
    {
        private readonly IBuyerRepository _buyerRepository;

        public GetBuyerAccountsQueryHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<ResponseBaseDto> Handle(GetBuyerAccountsQuery request)
        {
            var buyers = await _buyerRepository.GetUsersBySearchAndStatus(request.Search, request.Status);
            var buyerDto = buyers.Adapt<IEnumerable<UserViewModel>>();
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = buyerDto };
        }
    }
}
