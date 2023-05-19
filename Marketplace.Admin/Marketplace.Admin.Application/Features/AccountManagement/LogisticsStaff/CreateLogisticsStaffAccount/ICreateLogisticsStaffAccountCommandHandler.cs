using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.CreateLogisticsStaffAccount
{
    public interface ICreateLogisticsStaffAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(CreateLogisticsStaffAccountCommand request);
    }
}
