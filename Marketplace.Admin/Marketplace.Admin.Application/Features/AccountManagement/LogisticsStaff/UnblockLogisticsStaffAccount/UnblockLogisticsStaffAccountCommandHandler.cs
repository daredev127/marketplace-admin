using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.UnblockLogisticsStaffAccount
{
    public class UnblockLogisticsStaffAccountCommandHandler : IUnblockLogisticsStaffAccountCommandHandler
    {
        private readonly ILogisticsStaffRepository _logisticsStaffRepository;
        public UnblockLogisticsStaffAccountCommandHandler(ILogisticsStaffRepository logisticsStaffRepository)
        {
            _logisticsStaffRepository = logisticsStaffRepository;
        }

        public async Task<ResponseBaseDto> Handle(UnblockLogisticsStaffAccountCommand request)
        {
            var logisticsStaff = await _logisticsStaffRepository.FindByUsername(request.Username);
            if (logisticsStaff != null)
            {
                logisticsStaff.Status = Status.Active;
            }
            await _logisticsStaffRepository.UpdateAsync(logisticsStaff);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = logisticsStaff };
        }
    }
}
