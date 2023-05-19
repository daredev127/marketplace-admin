using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.Features.AccountManagement.Buyer.CreateBuyerAccount
{
    public interface ICreateBuyerAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(CreateBuyerAccountCommand request);
    }
}
