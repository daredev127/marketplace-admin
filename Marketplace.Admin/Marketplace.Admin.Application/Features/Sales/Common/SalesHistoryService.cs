using Marketplace.Admin.Application.Common;
using Marketplace.Admin.Application.Dtos;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace Marketplace.Admin.Application.Features.Sales.Common
{
    public class SalesHistoryService : ISalesHistoryService
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;

        public SalesHistoryService(IOptions<AppSettings> appSettings, ILogger<SalesHistoryService> logger)
        {
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        public async Task<IEnumerable<SalesHistoryDto>> GetSalesHistory()
        {
            var client = new RestClient(_appSettings.SalesHistoryConfig.Url);

            var request = new RestRequest
            {
                Resource = "api/v1/saleshistory",
                Method = Method.Get
            };

            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var salesHistory = JsonConvert.DeserializeObject<IEnumerable<SalesHistoryDto>>(response.Content);
                return salesHistory;
            }
            else
            {
                _logger.LogInformation(response.ErrorException?.StackTrace);
                _logger.LogInformation(response.ErrorMessage);
                _logger.LogInformation(response.Content);
            }

            return new List<SalesHistoryDto>();
        }
    }
}
