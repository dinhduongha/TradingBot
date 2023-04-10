using TradingBot.Core.Domain;
using TradingBot.HttpClients.ByBit;
using TradingBot.HttpClients.ByBit.RequestModels;

namespace TradingBot.HttpClients.Tests.ByBit
{
    public class MarketHttpClientsTests
    {
        private readonly MarketHttpClient _httpClient;

        public MarketHttpClientsTests(MarketHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Fact]
        public async Task GetKlineAsync_WithModel_ReturnNotNullAndEmptyResponse()
        {
            var model = new GetKlineRequestModel(Category.Spot, "ETHUSDT", Interval.FiveMinutes,
                DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);

            var response = await _httpClient.GetKlineAsync(model);

            Assert.NotNull(response);

            Assert.NotNull(response.Result);

            Assert.NotNull(response.Result.Values);
            Assert.NotEmpty(response.Result.Values);
        }

        [Fact]
        public async Task GetInstrumentsInfoAsync_WithModel_ReturnNotNullAndEmptyResponse()
        {
            var model = new GetInstrumentsInfoRequestModel(Category.Spot);

            var response = await _httpClient.GetInstrumentsInfoAsync(model);

            Assert.NotNull(response);

            Assert.NotNull(response.Result);

            Assert.NotNull(response.Result.Instruments);
            Assert.NotEmpty(response.Result.Instruments);
        }

        [Fact]
        public async Task GetOrderbookAsync_WithModel_ReturnNotNullAndEmptyResponse()
        {
            var model = new GetOrderbookRequestModel(Category.Spot, "ETHUSDT");

            var response = await _httpClient.GetOrderbookAsync(model);

            Assert.NotNull(response);

            Assert.NotNull(response.Result);

            Assert.NotNull(response.Result.Buyers);
            Assert.NotNull(response.Result.Sellers);

            Assert.NotEmpty(response.Result.Buyers);
            Assert.NotEmpty(response.Result.Sellers);
        }

        [Fact]
        public async Task GetTickersAsync_WithModel_ReturnNotNullAndEmptyResponse()
        {
            var model = new GetTickersRequestModel(Category.Spot);

            var response = await _httpClient.GetTickersAsync(model);

            Assert.NotNull(response);

            Assert.NotNull(response.Result);

            Assert.NotNull(response.Result.Tickers);
            Assert.NotEmpty(response.Result.Tickers);
        }
    }
}
