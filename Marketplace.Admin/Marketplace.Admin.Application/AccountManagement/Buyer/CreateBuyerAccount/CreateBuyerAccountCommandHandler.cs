using Mapster;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.AccountManagement.Buyer.CreateBuyerAccount
{
    public class CreateBuyerAccountCommandHandler : ICreateBuyerAccountCommandHandler
    {
        private readonly IBuyerRepository _buyerRepository;

        public CreateBuyerAccountCommandHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<ResponseBaseDto> Handle(CreateBuyerAccountCommand request)
        {
            if (await _buyerRepository.FindByUsername(request.Username) != null)
            {
                return new ResponseBaseDto { Status = "Error", Message = "Username already exists" };
            }

            var newBuyer = request.Adapt<Domain.Entities.Buyer>();
            newBuyer.Status = Status.Active;
            newBuyer.CreatedDate = DateTime.Now;
            newBuyer.CreatedBy = "Buyer";
            var buyer = await _buyerRepository.AddAsync(newBuyer);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = buyer };
        }
    }
}

