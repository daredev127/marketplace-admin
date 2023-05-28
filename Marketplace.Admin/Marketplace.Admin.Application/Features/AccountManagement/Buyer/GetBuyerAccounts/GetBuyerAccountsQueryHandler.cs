using Mapster;
using Marketplace.Admin.Application.Common;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Common;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.Buyer.GetBuyerAccounts
{
    public class GetBuyerAccountsQueryHandler : IGetBuyerAccountsQueryHandler
    {
        private readonly IBuyerRepository _buyerRepository;
        private readonly IBuyerService _buyerService;

        public GetBuyerAccountsQueryHandler(IBuyerRepository buyerRepository, IBuyerService buyerService)
        {
            _buyerRepository = buyerRepository;
            _buyerService = buyerService;
        }

        public async Task<ResponseBaseDto> Handle(GetBuyerAccountsQuery request)
        {
            //var buyers = await _buyerRepository.GetUsersBySearchAndStatus(request.Search, request.Status);
            var buyers = await _buyerService.GetBuyers();

            var buyerDto = buyers.Adapt<IEnumerable<UserViewModel>>();
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = buyerDto };
        }

    }
}
