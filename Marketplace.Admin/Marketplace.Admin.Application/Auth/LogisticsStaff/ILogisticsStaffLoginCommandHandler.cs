using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Auth.LogisticsStaff
{
    public interface ILogisticsStaffLoginCommandHandler
    {
        Task<ResponseBaseDto> Handle(LogisticsStaffLoginCommand request);
    }
}
