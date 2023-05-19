using Mapster;
using Marketplace.Admin.Application.Common;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.Seller.GetSellerAccounts
{
    public class GetSellerAccountsQueryHandler : IGetSellerAccountsQueryHandler
    {
        private readonly ISellerRepository _sellerRepository;

        public GetSellerAccountsQueryHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<ResponseBaseDto> Handle(GetSellerAccountsQuery request)
        {
            var sellers = await _sellerRepository.GetUsersBySearchAndStatus(request.Search, request.Status);
            var sellerDto = sellers.Adapt<IEnumerable<UserViewModel>>();
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = sellerDto };
        }
    }
}
