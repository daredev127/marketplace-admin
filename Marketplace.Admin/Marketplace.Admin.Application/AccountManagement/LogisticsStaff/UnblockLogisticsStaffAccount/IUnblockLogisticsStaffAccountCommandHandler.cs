using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.AccountManagement.LogisticsStaff.UnblockLogisticsStaffAccount
{
    public interface IUnblockLogisticsStaffAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(UnblockLogisticsStaffAccountCommand request);
    }
}
