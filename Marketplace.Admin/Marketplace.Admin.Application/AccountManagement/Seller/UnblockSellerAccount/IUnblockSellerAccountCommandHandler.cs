﻿using Marketplace.Admin.Application.Dtos;

namespace Marketplace.Admin.Application.AccountManagement.Seller.UnblockSellerAccount
{
    public interface IUnblockSellerAccountCommandHandler
    {
        Task<ResponseBaseDto> Handle(UnblockSellerAccountCommand request);
    }
}
