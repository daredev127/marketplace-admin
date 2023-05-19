using Mapster;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Auth;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.CreateLogisticsStaffAccount
{
    public class CreateLogisticsStaffAccountCommandHandler : ICreateLogisticsStaffAccountCommandHandler
    {
        private readonly ILogisticsStaffRepository _logisticsStaffRepository;
        private readonly IPasswordUtils _passwordUtil;
        public CreateLogisticsStaffAccountCommandHandler(ILogisticsStaffRepository logisticsStaffRepository, IPasswordUtils passwordUtil)
        {
            _logisticsStaffRepository = logisticsStaffRepository;
            _passwordUtil = passwordUtil;
        }

        public async Task<ResponseBaseDto> Handle(CreateLogisticsStaffAccountCommand request)
        {
            if (await _logisticsStaffRepository.FindByUsername(request.Username) != null)
            {
                return new ResponseBaseDto { Status = "Error", Message = "Username already exists" };
            }

            var newLogisticsStaff = request.Adapt<Domain.Entities.LogisticsStaff>();
            newLogisticsStaff.Password = _passwordUtil.GenerateHash(request.Password);
            newLogisticsStaff.Status = Status.Active;
            newLogisticsStaff.CreatedDate = DateTime.Now;
            newLogisticsStaff.CreatedBy = "LogisticsStaff";
            var logisticsStaff = await _logisticsStaffRepository.AddAsync(newLogisticsStaff);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = logisticsStaff };
        }
    }
}

