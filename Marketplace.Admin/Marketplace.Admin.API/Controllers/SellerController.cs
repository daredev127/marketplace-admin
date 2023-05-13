using Marketplace.Admin.Application.AccountManagement.Seller.BlockSellerAccount;
using Marketplace.Admin.Application.AccountManagement.Seller.CreateSellerAccount;
using Marketplace.Admin.Application.AccountManagement.Seller.GetSellerAccounts;
using Marketplace.Admin.Application.AccountManagement.Seller.UnblockSellerAccount;
using Marketplace.Admin.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Admin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : ControllerBase
    {
        private readonly IGetSellerAccountsQueryHandler _getSellerAccountsQueryHandler;
        private readonly ICreateSellerAccountCommandHandler _createSellerAccountCommandHandler;
        private readonly IBlockSellerAccountCommandHandler _blockSellerAccountHandler;
        private readonly IUnblockSellerAccountCommandHandler _unblockSellerAccountHandler;

        public SellerController(
            IGetSellerAccountsQueryHandler getSellerAccountsQueryHandler,
            ICreateSellerAccountCommandHandler createSellerAccountCommandHandler,
            IBlockSellerAccountCommandHandler blockSellerAccountHandler,
            IUnblockSellerAccountCommandHandler unblockSellerAccountHandler)
        {
            _getSellerAccountsQueryHandler = getSellerAccountsQueryHandler;
            _createSellerAccountCommandHandler = createSellerAccountCommandHandler;
            _blockSellerAccountHandler = blockSellerAccountHandler;
            _unblockSellerAccountHandler = unblockSellerAccountHandler;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetSellerAccounts([FromQuery] string search, string status)
        {
            var query = new GetSellerAccountsQuery(search, status);
            var SellerUsers = await _getSellerAccountsQueryHandler.Handle(query);
            return Ok(SellerUsers);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> CreateSellerAccount([FromBody] CreateSellerAccountCommand request)
        {
            var result = await _createSellerAccountCommandHandler.Handle(request);
            return Ok(result);
        }

        [HttpPut("block")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> BlockSellerAccount([FromBody] BlockSellerAccountCommand request)
        {
            var result = await _blockSellerAccountHandler.Handle(request);
            return Ok(result);
        }

        [HttpPut("unblock")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> UnblockSellerAccount([FromBody] UnblockSellerAccountCommand request)
        {
            var result = await _unblockSellerAccountHandler.Handle(request);
            return Ok(result);
        }
    }
}
