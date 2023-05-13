using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.AccountManagement.LogisticsStaff.GetLogisticsStaffAccounts
{
    public interface IGetLogisticsStaffAccountsQueryHandler
    {
        Task<ResponseBaseDto> Handle(GetLogisticsStaffAccountsQuery request);
    }
}
