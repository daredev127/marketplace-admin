using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.AccountManagement.Buyer.BlockBuyerAccount;
using Marketplace.Admin.Application.Features.AccountManagement.Buyer.CreateBuyerAccount;
using Marketplace.Admin.Application.Features.AccountManagement.Buyer.GetBuyerAccounts;
using Marketplace.Admin.Application.Features.AccountManagement.Buyer.UnblockBuyerAccount;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Admin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyerController : ControllerBase
    {
        private readonly IGetBuyerAccountsQueryHandler _getBuyerAccountsQueryHandler;
        private readonly ICreateBuyerAccountCommandHandler _createBuyerAccountCommandHandler;
        private readonly IBlockBuyerAccountCommandHandler _blockBuyerAccountHandler;
        private readonly IUnblockBuyerAccountCommandHandler _unblockBuyerAccountHandler;

        public BuyerController(
            IGetBuyerAccountsQueryHandler getBuyerAccountsQueryHandler,
            ICreateBuyerAccountCommandHandler createBuyerAccountCommandHandler,
            IBlockBuyerAccountCommandHandler blockBuyerAccountHandler,
            IUnblockBuyerAccountCommandHandler unblockBuyerAccountHandler)
        {
            _getBuyerAccountsQueryHandler = getBuyerAccountsQueryHandler;
            _createBuyerAccountCommandHandler = createBuyerAccountCommandHandler;
            _blockBuyerAccountHandler = blockBuyerAccountHandler;
            _unblockBuyerAccountHandler = unblockBuyerAccountHandler;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetBuyerAccounts([FromQuery] string search, string status)
        {
            var query = new GetBuyerAccountsQuery(search, status);
            var buyers = await _getBuyerAccountsQueryHandler.Handle(query);
            return Ok(buyers);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> CreateBuyerAccount([FromBody] CreateBuyerAccountCommand request)
        {
            var result = await _createBuyerAccountCommandHandler.Handle(request);
            return Ok(result);
        }

        [HttpPut("block")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> BlockBuyerAccount([FromBody] BlockBuyerAccountCommand request)
        {
            var result = await _blockBuyerAccountHandler.Handle(request);
            return Ok(result);
        }

        [HttpPut("unblock")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> UnblockBuyerAccount([FromBody] UnblockBuyerAccountCommand request)
        {
            var result = await _unblockBuyerAccountHandler.Handle(request);
            return Ok(result);
        }
    }
}
