using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Auth.Admin;
using Marketplace.Admin.Application.Features.Auth.Buyer;
using Marketplace.Admin.Application.Features.Auth.LogisticsStaff;
using Marketplace.Admin.Application.Features.Auth.Seller;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Admin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAdminLoginCommandHandler _adminLoginCommandHandler;
        private readonly IBuyerLoginCommandHandler _buyerLoginCommandHandler;
        private readonly ISellerLoginCommandHandler _sellerLoginCommandHandler;
        private readonly ILogisticsStaffLoginCommandHandler _logisticsStaffLoginCommandHandler;

        public LoginController(
            IAdminLoginCommandHandler adminLoginCommandHandler,
            IBuyerLoginCommandHandler buyerLoginCommandHandler,
            ISellerLoginCommandHandler sellerLoginCommandHandler,
            ILogisticsStaffLoginCommandHandler logisticsStaffLoginCommandHandler)
        {
            _adminLoginCommandHandler = adminLoginCommandHandler;
            _buyerLoginCommandHandler = buyerLoginCommandHandler;
            _sellerLoginCommandHandler = sellerLoginCommandHandler;
            _logisticsStaffLoginCommandHandler = logisticsStaffLoginCommandHandler;
        }

        [HttpPost("admin")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> AdminLogin([FromBody] AdminLoginCommand request)
        {
            var response = await _adminLoginCommandHandler.Handle(request);
            return Ok(response);
        }

        [HttpPost("buyer")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> BuyerLogin([FromBody] BuyerLoginCommand request)
        {
            var response = await _buyerLoginCommandHandler.Handle(request);
            return Ok(response);
        }

        [HttpPost("seller")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> SellerLogin([FromBody] SellerLoginCommand request)
        {
            var response = await _sellerLoginCommandHandler.Handle(request);
            return Ok(response);
        }

        [HttpPost("logistics")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> LogisticsLogin([FromBody] LogisticsStaffLoginCommand request)
        {
            var response = await _logisticsStaffLoginCommandHandler.Handle(request);
            return Ok(response);
        }
    }
}
