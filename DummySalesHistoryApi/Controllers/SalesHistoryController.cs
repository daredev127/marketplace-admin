using DummySalesHistoryApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DummySalesHistoryApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class SalesHistoryController : ControllerBase
    {
        private static readonly IEnumerable<SalesHistoryDto> DummySalesHistory = new List<SalesHistoryDto>
        {
            new SalesHistoryDto("Apple", 2, 1m, "Mike", "Parramatta", new DateTime(2023,5,1)),
            new SalesHistoryDto("Orange", 1, 15m, "Ana", "Westmead", new DateTime(2023,5,1)),
            new SalesHistoryDto("Apple", 7, 16m, "Andrew", "Epping", new DateTime(2023,5,1)),
            new SalesHistoryDto("Apple", 2, 7m, "Francis", "Parramatta", new DateTime(2023,5,1)),
            new SalesHistoryDto("Pork", 4, 8m, "Sarah", "Parramatta", new DateTime(2023,5,1)),
            new SalesHistoryDto("Beef", 2, 5m, "Josh", "Blacktown", new DateTime(2023,5,1)),
            new SalesHistoryDto("Fish", 1, 1m, "Selena", "Blacktown", new DateTime(2023,5,1)),
            new SalesHistoryDto("Orange", 7, 15m, "Mike", "Nirimba", new DateTime(2023,5,1)),
            new SalesHistoryDto("Banana", 5, 16m, "Mike", "Nirimba", new DateTime(2023,5,1)),
            new SalesHistoryDto("Coconut", 2, 12m, "Ana", "Parramatta", new DateTime(2023,5,1)),
            new SalesHistoryDto("Melon", 2, 11m, "Sarah", "Parramatta", new DateTime(2023,5,1)),
            new SalesHistoryDto("Chicken", 10, 19m, "Malika", "Northmead", new DateTime(2023,5,1)),
            new SalesHistoryDto("Chicken", 1, 20m, "Austin", "Northmead", new DateTime(2023,5,1)),
            new SalesHistoryDto("Honey", 5, 31m, "Jonathan", "Parramatta", new DateTime(2023,5,1)),
            new SalesHistoryDto("Rice", 2, 15m, "Karla", "Manly", new DateTime(2023,5,1)),
            new SalesHistoryDto("Rice", 3, 11m, "Karla", "Manly", new DateTime(2023,5,1))
        };

        [HttpGet]
        [ProducesResponseType(typeof(SalesHistoryResponseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesHistoryResponseDto>> GetSalesHistory()
        {
            return Ok(DummySalesHistory);
        }
    }


}
