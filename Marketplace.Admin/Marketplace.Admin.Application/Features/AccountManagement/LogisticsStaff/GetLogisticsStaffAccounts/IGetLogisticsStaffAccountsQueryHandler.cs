using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.GetLogisticsStaffAccounts
{
    public interface IGetLogisticsStaffAccountsQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetLogisticsStaffAccountsQuery request);
    }
}
