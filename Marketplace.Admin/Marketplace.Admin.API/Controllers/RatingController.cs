using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Rating.AddProductRating;
using Marketplace.Admin.Application.Features.Rating.GetProductRating;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Admin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IGetProductRatingQueryHandler _getProductRatingQueryHandler;
        private readonly IAddProductRatingCommandHandler _addProductRatingCommandHandler;

        public RatingController(IGetProductRatingQueryHandler getProductRatingQueryHandler, IAddProductRatingCommandHandler addProductRatingCommandHandler)
        {
            _getProductRatingQueryHandler = getProductRatingQueryHandler;
            _addProductRatingCommandHandler = addProductRatingCommandHandler;
        }

        [HttpGet("product")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetProductRatings([FromQuery] string productId)
        {
            var query = new GetProductRatingQuery(productId);
            var result = await _getProductRatingQueryHandler.Handle(query);
            return Ok(result);
        }

        [HttpPost("product")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> AddProductRating([FromBody] AddProductRatingCommand request)
        {
            var result = await _addProductRatingCommandHandler.Handle(request);
            return Ok(result);
        }
    }
}
