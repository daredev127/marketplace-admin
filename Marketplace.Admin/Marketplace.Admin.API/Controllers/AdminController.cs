using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.AccountManagement.Admin.BlockAdminAccount;
using Marketplace.Admin.Application.Features.AccountManagement.Admin.CreateAdminAccount;
using Marketplace.Admin.Application.Features.AccountManagement.Admin.GetAdminAccounts;
using Marketplace.Admin.Application.Features.AccountManagement.Admin.UnblockAdminAccount;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Admin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IGetAdminAccountsQueryHandler _getAdminAccountsQueryHandler;
        private readonly ICreateAdminAccountCommandHandler _createAdminAccountCommandHandler;
        private readonly IBlockAdminAccountCommandHandler _blockAdminAccountHandler;
        private readonly IUnblockAdminAccountCommandHandler _unblockAdminAccountHandler;

        public AdminController(
            IGetAdminAccountsQueryHandler getAdminAccountsQueryHandler,
            ICreateAdminAccountCommandHandler createAdminAccountCommandHandler,
            IBlockAdminAccountCommandHandler blockAdminAccountHandler,
            IUnblockAdminAccountCommandHandler unblockAdminAccountHandler)
        {
            _getAdminAccountsQueryHandler = getAdminAccountsQueryHandler;
            _createAdminAccountCommandHandler = createAdminAccountCommandHandler;
            _blockAdminAccountHandler = blockAdminAccountHandler;
            _unblockAdminAccountHandler = unblockAdminAccountHandler;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetAdminAccounts([FromQuery] string search, string status)
        {
            var query = new GetAdminAccountsQuery(search, status);
            var adminUsers = await _getAdminAccountsQueryHandler.Handle(query);
            return Ok(adminUsers);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> CreateAdminAccount([FromBody] CreateAdminAccountCommand request)
        {
            var result = await _createAdminAccountCommandHandler.Handle(request);
            return Ok(result);
        }

        [HttpPut("block")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> BlockAdminAccount([FromBody] BlockAdminAccountCommand request)
        {
            var result = await _blockAdminAccountHandler.Handle(request);
            return Ok(result);
        }

        [HttpPut("unblock")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> UnblockAdminAccount([FromBody] UnblockAdminAccountCommand request)
        {
            var result = await _unblockAdminAccountHandler.Handle(request);
            return Ok(result);
        }
    }
}
