using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.AccountManagement.Buyer.CreateBuyerAccount
{
    public interface ICreateBuyerAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(CreateBuyerAccountCommand request);
    }
}
