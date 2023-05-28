using Marketplace.Admin.Application.Dtos.ThirdParty;

namespace Marketplace.Admin.Application.Features.Common
{
    public interface IBuyerService
    {
        Task<List<BuyerDto>> GetBuyers();
    }
}
