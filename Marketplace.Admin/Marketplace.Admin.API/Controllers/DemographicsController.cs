using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Demographics.Buyer;
using Marketplace.Admin.Application.Features.Demographics.Seller;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Admin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemographicsController : ControllerBase
    {
        private readonly IGetBuyerDemographicsQueryHandler _getBuyerDemographicsQueryHandler;
        private readonly IGetSellerDemographicsQueryHandler _getSellerDemographicsQueryHandler;

        public DemographicsController(
            IGetBuyerDemographicsQueryHandler getBuyerDemographicsQueryHandler,
            IGetSellerDemographicsQueryHandler getSellerDemographicsQueryHandler)
        {
            _getBuyerDemographicsQueryHandler = getBuyerDemographicsQueryHandler;
            _getSellerDemographicsQueryHandler = getSellerDemographicsQueryHandler;
        }

        [HttpGet("buyer")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetBuyerDemographics()
        {
            var query = new GetBuyerDemographicsQuery();
            var demographics = await _getBuyerDemographicsQueryHandler.Handle(query);
            return Ok(demographics);
        }

        [HttpGet("seller")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetSellerDemographics()
        {
            var query = new GetSellerDemographicsQuery();
            var demographics = await _getSellerDemographicsQueryHandler.Handle(query);
            return Ok(demographics);
        }
    }
}
