using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.AccountManagement.Admin.BlockAdminAccount
{
    public interface IBlockAdminAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(BlockAdminAccountCommand request);
    }
}
