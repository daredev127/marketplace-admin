using Marketplace.Admin.Application.Common;
using Marketplace.Admin.Application.Dtos.ThirdParty;
using Marketplace.Admin.Application.Features.Sales.Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace Marketplace.Admin.Application.Features.Common
{
    public class BuyerService : IBuyerService
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;

        public BuyerService(IOptions<AppSettings> appSettings, ILogger<SalesHistoryService> logger)
        {
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        public async Task<List<BuyerDto>> GetBuyers()
        {
            var client = new RestClient("http://170.64.132.21:4000");

            var request = new RestRequest
            {
                Resource = "api/v1/user/getusers",
                Method = Method.Get
            };

            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var buyers = new List<BuyerDto>();
                var buyerData = JsonConvert.DeserializeObject<BuyerDataDto>(response.Content);
                if (buyerData?.Data == null)
                {
                    return buyers;
                }
                foreach (var buyer in buyerData.Data)
                {
                    if (buyer == null) continue;

                    buyers.Add(new BuyerDto
                    {
                        Username = buyer.Username,
                        Name = $"{buyer.FirstName} {buyer.LastName}",
                        State = buyer.State,
                    });
                }
                return buyers;
            }
            else
            {
                _logger.LogInformation(response.ErrorException?.StackTrace);
                _logger.LogInformation(response.ErrorMessage);
                _logger.LogInformation(response.Content);
            }

            return new List<BuyerDto>();
        }
    }
}
