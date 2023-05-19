using Marketplace.Admin.Application.Common;
using Marketplace.Admin.Application.Dtos;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace Marketplace.Admin.Application.Features.Sales.Common
{
    public class SalesHistoryService : ISalesHistoryService
    {
        private readonly AppSettings _appSettings;

        public SalesHistoryService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
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

            return new List<SalesHistoryDto>();
        }
    }
}
