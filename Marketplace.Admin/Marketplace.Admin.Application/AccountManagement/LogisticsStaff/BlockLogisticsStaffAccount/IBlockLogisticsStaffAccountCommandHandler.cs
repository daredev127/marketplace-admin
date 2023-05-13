using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.AccountManagement.LogisticsStaff.BlockLogisticsStaffAccount
{
    public interface IBlockLogisticsStaffAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(BlockLogisticsStaffAccountCommand request);
    }
}
