using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Sales.MarketplaceSummary;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Admin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketplaceController : ControllerBase
    {
        private readonly IMarketplaceSummaryAggregator _marketplaceSummaryAggregator;

        public MarketplaceController(IMarketplaceSummaryAggregator marketplaceSummaryAggregator)
        {
            _marketplaceSummaryAggregator = marketplaceSummaryAggregator;
        }

        [HttpGet("summary")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetMarketplaceSummary()
        {
            var marketplaceSummary = await _marketplaceSummaryAggregator.GetMarketplaceSummary();
            return Ok(marketplaceSummary);
        }
    }
}
