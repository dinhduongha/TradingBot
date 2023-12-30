using OKX.Api;
using OKX.Api.Clients.RestApi;
using OKX.Api.Enums;

namespace TradingBot.HttpClients.Tests.Okx
{
    public class OkexClientTests
    {
        private readonly OKXRestApiAlgoTradingClient _client;

        public OkexClientTests(OKXRestApiAlgoTradingClient client)
        {
            _client = client;
        }

        [Fact]
        public async Task GetTickersAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetTickersAsync(OkxInstrumentType.Spot);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetTickerAsync_WithParam_ReturnNotNullResult()
        {
            var response = await _client.GetTickerAsync("ETH-USDT-SWAP");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetIndexTickersAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetIndexTickersAsync(quoteCurrency: "USDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetOrderBookAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetOrderBookAsync("ETH-USDT");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.Asks);
            Assert.NotNull(response.Data.Bids);

            Assert.NotEmpty(response.Data.Asks);
            Assert.NotEmpty(response.Data.Bids);
        }

        [Fact]
        public async Task GetCandlesticksHistoryAsync_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetCandlesticksHistoryAsync("BTC-USDT", OkxPeriod.OneMinute);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetTradesAsync_WithParams_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetTradesAsync("ETH-USDT", 500);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetBlockTickersAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetBlockTickersAsync(OkxInstrumentType.Spot);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetInstrumentsAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetInstrumentsAsync(OkxInstrumentType.Spot);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetSystemTimeAsync_WithoutParams_ReturnNotNullResult()
        {
            var response = await _client.GetSystemTimeAsync();

            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetRubikTakerVolumeAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetRubikTakerVolumeAsync("ETH", OkxInstrumentType.Spot);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetRubikLongShortRatioAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetRubikLongShortRatioAsync("ETH");

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetRubikPutCallRatioAsync_WithParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetRubikPutCallRatioAsync("BTC", OkxPeriod.OneDay);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task GetRubikTakerFlowAsync_WithParam_ReturnNotNullResult()
        {
            var response = await _client.GetRubikTakerFlowAsync("BTC", OkxPeriod.OneDay);

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task GetAccountBalance_Async_WithoutParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetAccountBalance_Async();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);

            Assert.NotNull(response.Data.Details);
            Assert.NotEmpty(response.Data.Details);
        }

        [Fact]
        public async Task GetCurrenciesAsync_Async_WithoutParam_ReturnNotNullAndNotEmptyResult()
        {
            var response = await _client.GetCurrenciesAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);
        }
    }
}
