using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.BlockLogisticsStaffAccount
{
    public class BlockLogisticsStaffAccountCommandHandler : IBlockLogisticsStaffAccountCommandHandler
    {
        private readonly ILogisticsStaffRepository _logisticsStaffRepository;
        public BlockLogisticsStaffAccountCommandHandler(ILogisticsStaffRepository logisticsStaffRepository)
        {
            _logisticsStaffRepository = logisticsStaffRepository;
        }

        public async Task<ResponseBaseDto> Handle(BlockLogisticsStaffAccountCommand request)
        {
            var logisticsStaff = await _logisticsStaffRepository.FindByUsername(request.Username);
            if (logisticsStaff != null)
            {
                logisticsStaff.Status = Status.Blocked;
            }
            await _logisticsStaffRepository.UpdateAsync(logisticsStaff);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = logisticsStaff };
        }
    }
}
