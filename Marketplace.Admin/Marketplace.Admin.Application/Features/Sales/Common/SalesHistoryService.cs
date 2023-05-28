using Marketplace.Admin.Application.Common;
using Marketplace.Admin.Application.Dtos;
using Marketplace.Admin.Application.Dtos.ThirdParty;
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
                Resource = "api/orders",
                Method = Method.Get
            };

            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var salesHistory = new List<SalesHistoryDto>();
                var orderData = JsonConvert.DeserializeObject<OrderDataDto>(response.Content);
                if (orderData?.Data == null)
                {
                    return salesHistory;
                }
                foreach (var order in orderData.Data)
                {
                    if (order?.Order_Lines == null) continue;

                    foreach (var orderItem in order.Order_Lines)
                    {
                        if (orderItem?.Product == null) continue;
                        salesHistory.Add(new SalesHistoryDto
                        {
                            SellerName = order.Seller_Name,
                            ProductName = orderItem.Product.Name,
                            Price = orderItem.Product.Sale_Price / 100m,
                            Quantity = orderItem.Quantity,
                            BuyerLocation = order.Shipping_Address.State,
                            Timestamp = order.Created_At
                        });
                    }
                }
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
