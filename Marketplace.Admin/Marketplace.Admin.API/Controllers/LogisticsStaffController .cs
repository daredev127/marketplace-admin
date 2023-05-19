using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.BlockLogisticsStaffAccount;
using Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.CreateLogisticsStaffAccount;
using Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.GetLogisticsStaffAccounts;
using Marketplace.Admin.Application.Features.AccountManagement.LogisticsStaff.UnblockLogisticsStaffAccount;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Admin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogisticsStaffController : ControllerBase
    {
        private readonly IGetLogisticsStaffAccountsQueryHandler _getLogisticsStaffAccountsQueryHandler;
        private readonly ICreateLogisticsStaffAccountCommandHandler _createLogisticsStaffAccountCommandHandler;
        private readonly IBlockLogisticsStaffAccountCommandHandler _blockLogisticsStaffAccountHandler;
        private readonly IUnblockLogisticsStaffAccountCommandHandler _unblockLogisticsStaffAccountHandler;

        public LogisticsStaffController(
            IGetLogisticsStaffAccountsQueryHandler getLogisticsStaffAccountsQueryHandler,
            ICreateLogisticsStaffAccountCommandHandler createLogisticsStaffAccountCommandHandler,
            IBlockLogisticsStaffAccountCommandHandler blockLogisticsStaffAccountHandler,
            IUnblockLogisticsStaffAccountCommandHandler unblockLogisticsStaffAccountHandler)
        {
            _getLogisticsStaffAccountsQueryHandler = getLogisticsStaffAccountsQueryHandler;
            _createLogisticsStaffAccountCommandHandler = createLogisticsStaffAccountCommandHandler;
            _blockLogisticsStaffAccountHandler = blockLogisticsStaffAccountHandler;
            _unblockLogisticsStaffAccountHandler = unblockLogisticsStaffAccountHandler;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetLogisticsStaffAccounts([FromQuery] string search, string status)
        {
            var query = new GetLogisticsStaffAccountsQuery(search, status);
            var logisticsStaff = await _getLogisticsStaffAccountsQueryHandler.Handle(query);
            return Ok(logisticsStaff);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> CreateLogisticsStaffAccount([FromBody] CreateLogisticsStaffAccountCommand request)
        {
            var result = await _createLogisticsStaffAccountCommandHandler.Handle(request);
            return Ok(result);
        }

        [HttpPut("block")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> BlockLogisticsStaffAccount([FromBody] BlockLogisticsStaffAccountCommand request)
        {
            var result = await _blockLogisticsStaffAccountHandler.Handle(request);
            return Ok(result);
        }

        [HttpPut("unblock")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> UnblockLogisticsStaffAccount([FromBody] UnblockLogisticsStaffAccountCommand request)
        {
            var result = await _unblockLogisticsStaffAccountHandler.Handle(request);
            return Ok(result);
        }
    }
}
