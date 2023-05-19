using Mapster;
using Marketplace.Admin.Application.Common;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.GetLogisticsStaffAccounts
{
    public class GetLogisticsStaffAccountsQueryHandler : IGetLogisticsStaffAccountsQueryHandler
    {
        private readonly ILogisticsStaffRepository _logisticsStaffRepository;

        public GetLogisticsStaffAccountsQueryHandler(ILogisticsStaffRepository logisticsStaffRepository)
        {
            _logisticsStaffRepository = logisticsStaffRepository;
        }

        public async Task<ResponseBaseDto> Handle(GetLogisticsStaffAccountsQuery request)
        {
            var logisticsStaff = await _logisticsStaffRepository.GetUsersBySearchAndStatus(request.Search, request.Status);
            var logisticsStaffDto = logisticsStaff.Adapt<IEnumerable<UserViewModel>>();
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = logisticsStaffDto };
        }
    }
}
