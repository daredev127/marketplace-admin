using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Price;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Admin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly IGetPriceRangeQueryHandler _getPriceRangeQueryHandler;

        public PriceController(IGetPriceRangeQueryHandler getPriceRangeQueryHandler)
        {
            _getPriceRangeQueryHandler = getPriceRangeQueryHandler;
        }

        [HttpGet("range")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetPriceRange([FromQuery] string period)
        {
            var query = new GetPriceRangeQuery(period);
            var result = await _getPriceRangeQueryHandler.Handle(query);
            return Ok(result);
        }
    }
}
