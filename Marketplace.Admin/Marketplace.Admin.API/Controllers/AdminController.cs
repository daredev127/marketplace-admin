using Marketplace.Admin.Application.AccountManagement;
using Marketplace.Admin.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Admin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetAdmins([FromQuery] string search, string status)
        {
            var query = new GetAdminAccountsQuery(search, status);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        //[HttpPost]
        //[ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<IEnumerable<OrdersVm>>> AddAdmin(string userName)
        //{
        //    var query = new GetOrdersListQuery(userName);
        //    var orders = await _mediator.Send(query);
        //    return Ok(orders);
        //}
    }
}
