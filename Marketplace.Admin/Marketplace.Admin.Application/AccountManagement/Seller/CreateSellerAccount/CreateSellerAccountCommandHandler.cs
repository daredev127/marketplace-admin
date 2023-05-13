using Mapster;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Domain.Constants;
using Marketplace.Admin.Domain.Repositories;

namespace Marketplace.Admin.Application.AccountManagement.Seller.CreateSellerAccount
{
    public class CreateSellerAccountCommandHandler : ICreateSellerAccountCommandHandler
    {
        private readonly ISellerRepository _sellerRepository;
        public CreateSellerAccountCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<ResponseBaseDto> Handle(CreateSellerAccountCommand request)
        {
            if (await _sellerRepository.FindByUsername(request.Username) != null)
            {
                return new ResponseBaseDto { Status = "Error", Message = "Username already exists" };
            }

            var newSelle = request.Adapt<Domain.Entities.Seller>();
            newSelle.Status = Status.Active;
            newSelle.CreatedDate = DateTime.Now;
            newSelle.CreatedBy = "Seller";
            var sellerUser = await _sellerRepository.AddAsync(newSelle);
            return new ResponseBaseDto { Status = "OK", Message = "Success", Data = sellerUser };
        }
    }
}

