using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.Auth.LogisticsStaff
{
    public interface ILogisticsStaffLoginCommandHandler
    {
        Task<ResponseBaseDto> Handle(LogisticsStaffLoginCommand request);
    }
}
