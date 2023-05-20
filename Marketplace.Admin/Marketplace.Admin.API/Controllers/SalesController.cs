using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Features.Sales.ProductSalesDetails;
using Marketplace.Admin.Application.Features.Sales.SalesByLocation;
using Marketplace.Admin.Application.Features.Sales.SalesByQuantity;
using Marketplace.Admin.Application.Features.Sales.SalesBySeller;
using Marketplace.Admin.Application.Features.Sales.SalesHistory;
using Marketplace.Admin.Application.Features.Sales.SalesSummary;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Marketplace.Admin.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IGetSalesSummaryQueryHandler _getSalesSummaryQueryHandler;
        private readonly IGetSalesByLocationQueryHandler _getSalesByLocationQueryHandler;
        private readonly IGetSalesByQuantityQueryHandler _getSalesByQuantityQueryHandler;
        private readonly IGetSalesBySellerQueryHandler _getSalesBySellerQueryHandler;
        private readonly IGetSalesHistoryQueryHandler _getSalesHistoryQueryHandler;
        private readonly IGetProductSalesDetailsQueryHandler _getProductSalesDetailsQueryHandler;

        public SalesController(
            IGetSalesSummaryQueryHandler getSalesSummaryQueryHandler,
            IGetSalesByLocationQueryHandler getSalesByLocationQueryHandler,
            IGetSalesByQuantityQueryHandler getSalesByQuantityQueryHandler,
            IGetSalesBySellerQueryHandler getSalesBySellerQueryHandler,
            IGetSalesHistoryQueryHandler getSalesHistoryQueryHandler,
            IGetProductSalesDetailsQueryHandler getProductSalesDetailsQueryHandler)
        {
            _getSalesSummaryQueryHandler = getSalesSummaryQueryHandler;
            _getSalesByLocationQueryHandler = getSalesByLocationQueryHandler;
            _getSalesByQuantityQueryHandler = getSalesByQuantityQueryHandler;
            _getSalesBySellerQueryHandler = getSalesBySellerQueryHandler;
            _getSalesHistoryQueryHandler = getSalesHistoryQueryHandler;
            _getProductSalesDetailsQueryHandler = getProductSalesDetailsQueryHandler;
        }

        [HttpGet("summary")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetSalesSummary([FromQuery] string search, string period)
        {
            var query = new GetSalesSummaryQuery(period, search);
            var result = await _getSalesSummaryQueryHandler.Handle(query);
            return Ok(result);
        }

        [HttpGet("seller")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetSalesBySeller([FromQuery] string search, string period)
        {
            var query = new GetSalesBySellerQuery(period, search);
            var result = await _getSalesBySellerQueryHandler.Handle(query);
            return Ok(result);
        }

        [HttpGet("history")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetSalesHistory([FromQuery] string period)
        {
            var query = new GetSalesHistoryQuery(period);
            var result = await _getSalesHistoryQueryHandler.Handle(query);
            return Ok(result);
        }

        [HttpGet("location")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetSalesByLocation([FromQuery] string period)
        {
            var query = new GetSalesByLocationQuery(period);
            var result = await _getSalesByLocationQueryHandler.Handle(query);
            return Ok(result);
        }

        [HttpGet("quantity")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetSalesByQuantity([FromQuery] string period)
        {
            var query = new GetSalesByQuantityQuery(period);
            var result = await _getSalesByQuantityQueryHandler.Handle(query);
            return Ok(result);
        }

        [HttpGet("product")]
        [ProducesResponseType(typeof(ResponseBaseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseBaseDto>> GetProductSalesDetails([FromQuery] string period, string productName)
        {
            var query = new GetProductSalesDetailsQuery(period, productName);
            var result = await _getProductSalesDetailsQueryHandler.Handle(query);
            return Ok(result);
        }
    }
}
