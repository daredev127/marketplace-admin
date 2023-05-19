using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.AccountManagement.Admin.BlockAdminAccount
{
    public interface IBlockAdminAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(BlockAdminAccountCommand request);
    }
}
