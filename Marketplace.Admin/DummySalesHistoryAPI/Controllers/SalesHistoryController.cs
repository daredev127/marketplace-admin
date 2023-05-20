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
            new SalesHistoryDto("Apple", 2, 1m, "Mike", "Parramatta", new DateTime(2023,1,1)),
            new SalesHistoryDto("Orange", 1, 15m, "Ana", "Westmead", new DateTime(2023,3,15)),
            new SalesHistoryDto("Apple", 7, 16m, "Andrew", "Epping", new DateTime(2023,5,10)),
            new SalesHistoryDto("Apple", 2, 7m, "Francis", "Parramatta", new DateTime(2023,4,5)),
            new SalesHistoryDto("Pork", 4, 8m, "Sarah", "Parramatta", new DateTime(2023,2,7)),
            new SalesHistoryDto("Beef", 2, 5m, "Josh", "Blacktown", new DateTime(2023,1,8)),
            new SalesHistoryDto("Fish", 1, 1m, "Selena", "Blacktown", new DateTime(2023,3,1)),
            new SalesHistoryDto("Orange", 7, 15m, "Mike", "Nirimba", new DateTime(2023,5,8)),
            new SalesHistoryDto("Banana", 5, 16m, "Mike", "Nirimba", new DateTime(2023,3,6)),
            new SalesHistoryDto("Coconut", 2, 12m, "Ana", "Parramatta", new DateTime(2023,5,21)),
            new SalesHistoryDto("Melon", 2, 11m, "Sarah", "Parramatta", new DateTime(2023,5,11)),
            new SalesHistoryDto("Chicken", 10, 19m, "Malika", "Northmead", new DateTime(2023,4,21)),
            new SalesHistoryDto("Chicken", 1, 20m, "Austin", "Northmead", new DateTime(2023,4,24)),
            new SalesHistoryDto("Honey", 5, 31m, "Jonathan", "Parramatta", new DateTime(2023,3,11)),
            new SalesHistoryDto("Rice", 2, 15m, "Karla", "Manly", new DateTime(2023,3,7)),
            new SalesHistoryDto("Rice", 3, 11m, "Karla", "Manly", new DateTime(2023,5,9))
        };

        [HttpGet]
        [ProducesResponseType(typeof(SalesHistoryResponseDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesHistoryResponseDto>> GetSalesHistory()
        {
            return Ok(DummySalesHistory);
        }
    }


}
