using MapsterMapper;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Entities;
using Marketplace.Admin.Domain.Repositories;
using MediatR;

namespace Marketplace.Admin.Application.AccountManagement
{
    internal class GetAdminAccountsQueryHandler : IRequestHandler<GetAdminAccountsQuery, ResponseBaseDto>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetAdminAccountsQueryHandler(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<ResponseBaseDto> Handle(GetAdminAccountsQuery request, CancellationToken cancellationToken)
        {
            var adminUsers = await _adminRepository.GetAdminUsersBySearchAndStatus(request.Search, request.Status);
            var adminUserDto = _mapper.Map<IEnumerable<AdminUser>>(adminUsers);
            return new ResponseBaseDto { Status = "OK", Message = "Admin Users", Data = adminUserDto };
        }
    }
}
