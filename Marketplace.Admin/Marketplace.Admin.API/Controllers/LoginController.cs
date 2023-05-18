using Marketplace.Admin.Application.Auth.Seller;
using Marketplace.Admin.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Admin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ISellerLoginCommandHandler _sellerLoginCommandHandler;

        public LoginController(ISellerLoginCommandHandler sellerLoginCommandHandler)
        {
            _sellerLoginCommandHandler = sellerLoginCommandHandler;
        }

        [HttpPost("seller")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> SellerLogin([FromBody] SellerLoginCommand request)
        {
            var response = await _sellerLoginCommandHandler.Handle(request);
            return Ok(response);
        }
    }
}
